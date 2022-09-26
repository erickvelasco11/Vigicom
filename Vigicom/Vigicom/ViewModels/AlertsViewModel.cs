using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class AlertsViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnSend1Command { get; set; }
        public IAsyncCommand BtnSend2Command { get; set; }
        public IAsyncCommand BtnSend3Command { get; set; }
        public IAsyncCommand BtnSend4Command { get; set; }
        public IAsyncCommand BtnSend5Command { get; set; }
        public IAsyncCommand BtnSend6Command { get; set; }
        public IAsyncCommand BtnSend7Command { get; set; }
        public IAsyncCommand BtnSend8Command { get; set; }

        public AlertsViewModel() { }

        public AlertsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSend1Command = new AsyncCommand(BtnSend1Click);
            BtnSend2Command = new AsyncCommand(BtnSend2Click);
            BtnSend3Command = new AsyncCommand(BtnSend3Click);
            BtnSend4Command = new AsyncCommand(BtnSend4Click);
            BtnSend5Command = new AsyncCommand(BtnSend5Click);
            BtnSend6Command = new AsyncCommand(BtnSend6Click);
            BtnSend7Command = new AsyncCommand(BtnSend7Click);
            BtnSend8Command = new AsyncCommand(BtnSend8Click);

            IsBusy = true;
            Number1 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "1", "");
            Number2 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "2", "");
            Number3 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "3", "");
            Number4 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "4", "");
            Number5 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "5", "");
            Number6 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "6", "");
            Number7 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "7", "");
            Number8 = Preferences.Get(Constants.KEY_ALERT_NUMBER + "8", "");
            Type1 = Preferences.Get(Constants.KEY_ALERT_TYPE + "1", "");
            Type2 = Preferences.Get(Constants.KEY_ALERT_TYPE + "2", "");
            Type3 = Preferences.Get(Constants.KEY_ALERT_TYPE + "3", "");
            Type4 = Preferences.Get(Constants.KEY_ALERT_TYPE + "4", "");
            Type5 = Preferences.Get(Constants.KEY_ALERT_TYPE + "5", "");
            Type6 = Preferences.Get(Constants.KEY_ALERT_TYPE + "6", "");
            Type7 = Preferences.Get(Constants.KEY_ALERT_TYPE + "7", "");
            Type8 = Preferences.Get(Constants.KEY_ALERT_TYPE + "8", "");
        }


        private async Task BtnSend1Click()
        {
            SendSms(Number1, Type1, 1);
        }
        private async Task BtnSend2Click()
        {
            SendSms(Number2, Type2, 2);
        }
        private async Task BtnSend3Click()
        {
            SendSms(Number3, Type3, 3);
        }
        private async Task BtnSend4Click()
        {
            SendSms(Number4, Type4, 4);
        }
        private async Task BtnSend5Click()
        {
            SendSms(Number5, Type5, 5);
        }
        private async Task BtnSend6Click()
        {
            SendSms(Number6, Type6, 6);
        }
        private async Task BtnSend7Click()
        {
            SendSms(Number7, Type7, 7);
        }
        private async Task BtnSend8Click()
        {
            SendSms(Number8, Type8, 8);
        }

        private string number1 = "";
        public string Number1
        {
            get => number1;
            set => SetProperty(ref number1, value);
        }

        private string number2 = "";
        public string Number2
        {
            get => number2;
            set => SetProperty(ref number2, value);
        }

        private string number3 = "";
        public string Number3
        {
            get => number3;
            set => SetProperty(ref number3, value);
        }

        private string number4 = "";
        public string Number4
        {
            get => number4;
            set => SetProperty(ref number4, value);
        }

        private string number5 = "";
        public string Number5
        {
            get => number5;
            set => SetProperty(ref number5, value);
        }

        private string number6 = "";
        public string Number6
        {
            get => number6;
            set => SetProperty(ref number6, value);
        }

        private string number7 = "";
        public string Number7
        {
            get => number7;
            set => SetProperty(ref number7, value);
        }

        private string number8 = "";
        public string Number8
        {
            get => number8;
            set => SetProperty(ref number8, value);
        }

        private string type1 = "";
        public string Type1
        {
            get => type1;
            set => SetProperty(ref type1, value);
        }

        private string type2 = "";
        public string Type2
        {
            get => type2;
            set => SetProperty(ref type2, value);
        }

        private string type3 = "";
        public string Type3
        {
            get => type3;
            set => SetProperty(ref type3, value);
        }

        private string type4 = "";
        public string Type4
        {
            get => type4;
            set => SetProperty(ref type4, value);
        }

        private string type5 = "";
        public string Type5
        {
            get => type5;
            set => SetProperty(ref type5, value);
        }

        private string type6 = "";
        public string Type6
        {
            get => type6;
            set => SetProperty(ref type6, value);
        }

        private string type7 = "";
        public string Type7
        {
            get => type7;
            set => SetProperty(ref type7, value);
        }

        private string type8 = "";
        public string Type8
        {
            get => type8;
            set => SetProperty(ref type8, value);
        }

        private async void SendSms(string number, string type, int position)
        {
            if (number == "" || type == "")
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
            await Tools.SendSMS("Cambio de alerta posición " + position, "*AP01,{UserPassword}," + position + "," + number + "," + type.Substring(0, 1));
            Preferences.Set(Constants.KEY_ALERT_NUMBER + position, number);
            Preferences.Set(Constants.KEY_ALERT_TYPE + position, type);
            IsBusy = true;
        }
    }
}
