﻿using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Vigicom.Pages;

using Xamarin.Forms;

namespace Vigicom.ViewModels
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
            IsBusy = true;
        }

        private async Task BtnUsersClick()
        {
            await Navigation.PushAsync(new UsersPage());
        }

        private async Task BtnAdministratorsClick()
        {
        }

        private async Task BtnIdAlarmClick()
        {
        }

        private async Task BtnSirenTimesClick()
        {
        }

        private async Task BtnTestSirenClick()
        {
            IsBusy = false;
            IsBusy = true;
        }

        private async Task BtnTestSmsClick()
        {
            IsBusy = false;
            IsBusy = true;
        }
    }
}
