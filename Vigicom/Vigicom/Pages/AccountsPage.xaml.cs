
using System;
using System.Threading.Tasks;

using Vigicom.Models;
using Vigicom.ViewModels;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigicom.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountsPage : ContentPage
    {
        public AccountsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AccountsViewModel(Navigation);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Preferences.Set(Constants.KEY_CURRENT_ACCOUNT_ID, (e.Item as Account).Id.ToString());
            await Navigation.PopAsync();
        }
    }
}