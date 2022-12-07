using System.Threading.Tasks;

using Xamarin.Essentials;

namespace VigicomPlus.Services
{
    public class ConnectivityService
    {
        private static ConnectivityService instance;

        public static ConnectivityService Instance => instance ??= new ConnectivityService();


        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch
            {
                throw;
            }
        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch
            {
                throw;
            }
        }
    }
}
