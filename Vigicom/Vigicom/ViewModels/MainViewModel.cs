using System;
using System.Collections.Generic;
using System.Text;

using Vigicom.Services;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class MainViewModel : MyBaseViewModel
    {
        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Init();
        }

        private async void Init()
        {
            var currentId = Guid.Parse(Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString()));
            var currentAccount = await AccountService.Instance.GetAccount(currentId);
            Title = currentAccount.Name;
        }
    }
}
