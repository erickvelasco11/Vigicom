using System;
using System.Threading.Tasks;
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


        private bool allowClick = true;
        public bool AllowClick
        {
            get => allowClick;
            set => SetProperty(ref allowClick, value);
        }

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
            var currentAccount = await DbService.Instance.Single<Account>(currentId);
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
            await CallNumber("SOS Click");
        }

        private async void BtnFireClick()
        {
            await SendSMS("Fire Click");
        }

        private async void BtnHospitalClick()
        {
            await SendSMS("Hospital Click");
        }

        private async void BtnAssistanceClick()
        {
            await SendSMS("Asistencia Click");
        }

        private async Task SendSMS(string type)
        {
            AllowClick = false;
            var currentAccountId = Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString());
            var currentAccount = await DbService.Instance.Single<Account>(Guid.Parse(currentAccountId));
            var register = new Historical
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "SMS " + type + " enviado a " + currentAccount.SimNumber,
                AccountId = currentAccount.Id
            };
            await DbService.Instance.Add(register);
            await ConnectivityService.Instance.SendSms(type, currentAccount.SimNumber);
            AllowClick = true;
        }

        private async Task CallNumber(string type)
        {
            AllowClick = false;
            var currentAccountId = Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString());
            var currentAccount = await DbService.Instance.Single<Account>(Guid.Parse(currentAccountId));
            var register = new Historical
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Called " + type + " enviado a " + currentAccount.SimNumber,
                AccountId = currentAccount.Id
            };
            await DbService.Instance.Add(register);
            ConnectivityService.Instance.PlacePhoneCall(currentAccount.SimNumber);
            AllowClick = true;
        }
    }
}
