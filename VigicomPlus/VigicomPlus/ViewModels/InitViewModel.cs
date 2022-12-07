using System;
using System.Linq;
using System.Threading.Tasks;

using VigicomPlus.Pages;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace VigicomPlus.ViewModels
{
    public class InitViewModel
    {
        private INavigation Navigation { get; set; }

        public InitViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        public async void GoToMainPage()
        {
            await Task.Delay(2000);
            if (Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString()) != Guid.Empty.ToString())
            {
                await Navigation.PushAsync(new MainPage(), true);
            }
            else
            {
                await Navigation.PushAsync(new CreateAccountPage(), true);
            }

            Navigation.RemovePage(Navigation.NavigationStack.First());
        }
    }
}
