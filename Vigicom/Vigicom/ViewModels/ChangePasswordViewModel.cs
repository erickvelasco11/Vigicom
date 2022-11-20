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

            if (password.Length != 4)
            {
                await DisplayAlert("Campos incompleto", "La contraseña debe ser de 4 caracteres.", "Entendido");
                return;
            }

            IsBusy = false;
            if (await Tools.SendSMS("Cambio de contraseña de alarma.", "*AP05,{AlarmPassword}," + password))
            {
                Preferences.Set(Constants.KEY_ALARM_PASSWORD, password);
            }
            else
            {
                await DisplayAlert("Error", "Clave de programación no configurada.", "Entendido");
            }
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
