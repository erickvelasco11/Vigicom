using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using VigicomPlus.Pages;

using Xamarin.Forms;

namespace VigicomPlus.ViewModels
{
    public class ProgrammingViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnPasswordCommand { get; set; }
        public IAsyncCommand BtnUsersCommand { get; set; }
        public IAsyncCommand BtnAdministratorsCommand { get; set; }
        public IAsyncCommand BtnIdAlarmCommand { get; set; }
        public IAsyncCommand BtnSirenTimesCommand { get; set; }
        public IAsyncCommand BtnTestSirenCommand { get; set; }
        public IAsyncCommand BtnTestSmsCommand { get; set; }

        public ProgrammingViewModel() { }

        public ProgrammingViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnPasswordCommand = new AsyncCommand(BtnPasswordClick);
            BtnUsersCommand = new AsyncCommand(BtnUsersClick);
            BtnAdministratorsCommand = new AsyncCommand(BtnAdministratorsClick);
            BtnIdAlarmCommand = new AsyncCommand(BtnIdAlarmClick);
            BtnSirenTimesCommand = new AsyncCommand(BtnSirenTimesClick);
            BtnTestSirenCommand = new AsyncCommand(BtnTestSirenClick);
            BtnTestSmsCommand = new AsyncCommand(BtnTestSmsClick);
            IsBusy = true;
        }

        private async Task BtnPasswordClick()
        {
            IsBusy = false;
            await Navigation.PushAsync(new ChangePasswordPage());
            IsBusy = true;
        }

        private async Task BtnUsersClick()
        {
            await Navigation.PushAsync(new UsersPage());
        }

        private async Task BtnAdministratorsClick()
        {
            await Navigation.PushAsync(new AlertsPage());
        }

        private async Task BtnIdAlarmClick()
        {
            await Navigation.PushAsync(new PanelNamePage());
        }

        private async Task BtnSirenTimesClick()
        {
            await Navigation.PushAsync(new TimesPage());
        }

        private async Task BtnTestSirenClick()
        {
            IsBusy = false;
            if(!await Tools.SendSMS("Prueba Sirena.", "*AP12,{AlarmPassword},1"))
            {
                await DisplayAlert("Error", "Clave de programación no configurada.", "Entendido");
            }
            IsBusy = true;
        }

        private async Task BtnTestSmsClick()
        {
            IsBusy = false;
            if(!await Tools.SendSMS("Prueba SMS.", "*AP12,{AlarmPassword},2"))
            {
                await DisplayAlert("Error", "Clave de programación no configurada.", "Entendido");
            }
            IsBusy = true;
        }
    }
}
