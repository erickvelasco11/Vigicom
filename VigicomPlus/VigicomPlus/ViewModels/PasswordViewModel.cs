using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using VigicomPlus.Pages;

using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VigicomPlus.ViewModels
{
    public class PasswordViewModel : MyBaseViewModel
    {
        private int currentPosition = 0;
        public ICommand BtnNumberCommand { get; set; }
        public IAsyncCommand BtnAcceptCommand { get; set; }
        public ICommand BtnBackCommand { get; set; }

        public PasswordViewModel() { }

        public PasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnNumberCommand = new Command<string>(BtnNumberClick);
            BtnAcceptCommand = new AsyncCommand(BtnAcceptClick);
            BtnBackCommand = new Command(BtnBackClick);
        }

        private void BtnNumberClick(string number)
        {
            switch (currentPosition)
            {
                case 0:
                    Number1 = number;
                    break;
                case 1:
                    Number2 = number;
                    break;
                case 2:
                    Number3 = number;
                    break;
                case 3:
                    Number4 = number;
                    break;
            }

            currentPosition++;
        }

        private async Task BtnAcceptClick()
        {
            var password = Preferences.Get(Constants.KEY_ALARM_PASSWORD, "");
            if ((string.IsNullOrEmpty(password) && CurrentPassword() == "0000") || (CurrentPassword().Length == 4 && CurrentPassword() == password))
            {
                var page = Navigation.NavigationStack.Last();
                await Navigation.PushAsync(new ProgrammingPage());
                Navigation.RemovePage(page);
            }
            else
            {
                currentPosition = 0;
                Number1 = "";
                Number2 = "";
                Number3 = "";
                Number4 = "";
                await DisplayAlert("Error", "Clave incorrecta. Intenta nuevamente.", "Entendido");
            }
        }

        private void BtnBackClick()
        {
            switch (currentPosition)
            {
                case 1:
                    currentPosition--;
                    Number1 = "";
                    break;
                case 2:
                    currentPosition--;
                    Number2 = "";
                    break;
                case 3:
                    currentPosition--;
                    Number3 = "";
                    break;
                default:
                    currentPosition = 3;
                    Number4 = "";
                    break;
            }
        }

        private string CurrentPassword()
        {
            return Number1 + Number2 + Number3 + Number4;
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
    }
}
