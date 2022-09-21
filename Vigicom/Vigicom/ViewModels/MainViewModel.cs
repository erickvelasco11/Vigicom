using System;
using System.Windows.Input;

using Vigicom.Models;
using Vigicom.Pages;
using Vigicom.Services;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class MainViewModel : MyBaseViewModel
    {
        public ICommand MenAccountsCommand { get; }
        public ICommand MenProgramationCommand { get; }
        public ICommand MenHistoricalCommand { get; }
        public ICommand BtnSosCommand { get; }
        public ICommand BtnFireCommand { get; }
        public ICommand BtnHospitalCommand { get; }
        public ICommand BtnAssistanceCommand { get; }

        public MainViewModel()
        {
        }

        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Init();

            MenAccountsCommand = new Command(MenAccountsClick);
            MenProgramationCommand = new Command(MenProgramationClick);
            MenHistoricalCommand = new Command(MenHistoricalClick);
            BtnSosCommand = new Command(BtnSosClick);
            BtnFireCommand = new Command(BtnFireClick);
            BtnHospitalCommand = new Command(BtnHospitalClick);
            BtnAssistanceCommand = new Command(BtnAssistanceClick);
        }

        private async void Init()
        {
            var currentId = Guid.Parse(Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString()));
            var currentAccount = await DbService.Instance.Get<Account>(currentId);
            Title = currentAccount.Name;
        }

        private async void MenAccountsClick()
        {
            await Navigation.PushAsync(new AccountsPage());
        }

        private async void MenProgramationClick()
        {
            await Navigation.PushAsync(new ProgrammingPage());
        }

        private async void MenHistoricalClick()
        {
            await Navigation.PushAsync(new HistoricalPage());
        }

        private async void BtnSosClick()
        {
        }

        private async void BtnFireClick()
        {
        }

        private async void BtnHospitalClick()
        {
        }

        private async void BtnAssistanceClick()
        {
        }
    }
}
