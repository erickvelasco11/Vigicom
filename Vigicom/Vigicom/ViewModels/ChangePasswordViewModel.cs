using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class ChangePasswordViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnSendSmsCommand { get; set; }

        public ChangePasswordViewModel() { }

        public ChangePasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSendSmsCommand = new AsyncCommand(BtnSendSmsClick);
            IsBusy = true;
            Password = Preferences.Get(Constants.KEY_ALARM_PASSWORD, "");
        }

        private async Task BtnSendSmsClick()
        {
            if (password == "")
            {
                await DisplayAlert("Campos vacíos", "Todos los campos deben ser diligenciados.", "Entendido");
                return;
            }

            IsBusy = false;
            await Tools.SendSMS("Cambio de contraseña de alarma.", "*AP02,{UserPassword}," + password);
            Preferences.Set(Constants.KEY_ALARM_PASSWORD, password);
            IsBusy = true;
        }

        private string password = "";
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
