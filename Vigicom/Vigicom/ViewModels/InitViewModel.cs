using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Vigicom.Pages;
using Vigicom.Services;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class InitViewModel
    {
        private INavigation Navigation { get; set; }

        public InitViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        public void GoToMainPage()
        {
            Task.Run(async () =>
            {
                Thread.Sleep(20/*00*/);
            }).ContinueWith(async task =>
            {
                if (Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString()) != Guid.Empty.ToString())
                {
                    await Navigation.PushAsync(new MainPage(), true);
                }
                else
                {
                    await Navigation.PushAsync(new CreateAccountPage(), true);
                }

                Navigation.RemovePage(Navigation.NavigationStack.First());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
