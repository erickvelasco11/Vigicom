using System;
using System.Threading.Tasks;

using VigicomPlus.Models;
using VigicomPlus.Services;

using Xamarin.Essentials;

namespace VigicomPlus
{
    public class Tools
    {
        public static async Task<bool> SendSMS(string text, string sms)
        {
            var alarmPassword = Preferences.Get(Constants.KEY_ALARM_PASSWORD, "");
            if (alarmPassword == string.Empty && sms.Contains("{AlarmPassword}"))
            {
                return false;
            }

            var currentAccountId = Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString());
            var currentAccount = await DbService.Instance.Single<Account>(Guid.Parse(currentAccountId));
            sms = sms.Replace("{UserPassword}", currentAccount.UserPassword);
            sms = sms.Replace("{AlarmPassword}", alarmPassword);

            var register = new Historical
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "SMS enviado a " + currentAccount.SimNumber + ". " + text,
                AccountId = currentAccount.Id
            };
            await DbService.Instance.Add(register);
            await ConnectivityService.Instance.SendSms(sms, currentAccount.SimNumber);
            return true;
        }

        public static async Task CallNumber(string text)
        {
            var currentAccountId = Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString());
            var currentAccount = await DbService.Instance.Single<Account>(Guid.Parse(currentAccountId));
            var register = new Historical
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Llamada a " + currentAccount.SimNumber + ". " + text,
                AccountId = currentAccount.Id
            };
            await DbService.Instance.Add(register);
            ConnectivityService.Instance.PlacePhoneCall(currentAccount.SimNumber);
        }
    }
}
