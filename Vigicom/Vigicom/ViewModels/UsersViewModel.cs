using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class UsersViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnSendSmsCommand { get; set; }
        public IAsyncCommand<string> EdtPositionTextChangedCommand { get; set; }

        public UsersViewModel() { }

        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSendSmsCommand = new AsyncCommand(BtnSendSmsClick);
            EdtPositionTextChangedCommand = new AsyncCommand<string>(EdtPositionTextChangedClick);
            IsBusy = true;
            Position = Preferences.Get(Constants.KEY_USERS_POSITION, "");
            Number = Preferences.Get(Constants.KEY_USERS_NUMBER, "");
            Name = Preferences.Get(Constants.KEY_USERS_NAME, "");
        }

        private async Task EdtPositionTextChangedClick(string newValue)
        {
            Position = Position.Replace("-", "");
            Position = Position.Replace(".", "");
            Position = Position.Replace(",", "");
            if (int.TryParse(newValue, out int intValue))
            {
                if (intValue < 0)
                {
                    Position = "0";
                }

                if (intValue > 255)
                {
                    Position = "255";
                }
            }
        }

        private async Task BtnSendSmsClick()
        {
            if (position == "" || number == "" || name == "")
            {
                await DisplayAlert("Campos vacíos", "Todos los campos deben ser diligenciados.", "Entendido");
                return;
            }

            if (number.Length != 10)
            {
                await DisplayAlert("Número incorrecto", "El número debe tener 10 dígitos.", "Entendido");
                return;
            }

            IsBusy = false;
            await Tools.SendSMS("Cambio de data del usuario", "*AP03,{UserPassword}," + position + "," + number + "," + name);
            Preferences.Set(Constants.KEY_USERS_POSITION, position);
            Preferences.Set(Constants.KEY_USERS_NUMBER, number);
            Preferences.Set(Constants.KEY_USERS_NAME, name);
            IsBusy = true;
        }

        private string position = "";
        public string Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }

        private string number = "";
        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }

        private string name = "";
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
    }
}
