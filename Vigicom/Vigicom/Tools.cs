using System;
using System.Threading.Tasks;

using Vigicom.Models;
using Vigicom.Services;

using Xamarin.Essentials;

namespace Vigicom
{
    public class Tools
    {
        public static async Task SendSMS(string text, string sms)
        {
            var currentAccountId = Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString());
            var currentAccount = await DbService.Instance.Single<Account>(Guid.Parse(currentAccountId));
            sms = sms.Replace("{UserPassword}", currentAccount.UserPassword);
            var register = new Historical
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "SMS enviado a " + currentAccount.SimNumber + ". " + text,
                AccountId = currentAccount.Id
            };
            await DbService.Instance.Add(register);
            await ConnectivityService.Instance.SendSms(sms, currentAccount.SimNumber);
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
