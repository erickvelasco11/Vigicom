using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System;
using System.Linq;
using System.Threading.Tasks;

using Vigicom.Models;
using Vigicom.Pages;
using Vigicom.Services;

using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class AccountsViewModel : MyBaseViewModel
    {
        public ObservableRangeCollection<Account> Accounts { get; set; }

        public IAsyncCommand<Account> ItmOptionsCommand { get; set; }
        public IAsyncCommand MenAddNewAccountCommand { get; set; }

        public AccountsViewModel()
        {

        }

        public AccountsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Accounts = new ObservableRangeCollection<Account>();
            ItmOptionsCommand = new AsyncCommand<Account>(ItmOptionsClick);
            MenAddNewAccountCommand = new AsyncCommand(MenAddNewAccountClick);
            FillList();
        }

        private async void FillList()
        {
            var accounts = await DbService.Instance.GetAll<Account>();
            Accounts.AddRange(accounts);
        }

        private async Task MenAddNewAccountClick()
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }

        private async Task ItmOptionsClick(Account account)
        {
            var popup = new AccountMenuPopup();
            string action = (await Application.Current.MainPage.Navigation.ShowPopupAsync(popup)).ToString();
            //string action = await Application.Current.MainPage.DisplayActionSheet("Cuenta " + account.Name, "Cancelar", null, "Editar", "Eliminar");
            switch (action)
            {
                case "Editar":
                    await MenEditAccountClick(account);
                    break;
                case "Eliminar":
                    await MenDeleteAccountClick(account);
                    break;
            }
        }

        private async Task MenEditAccountClick(Account account)
        {
            await Navigation.PushAsync(new CreateAccountPage(account));
        }

        private async Task MenDeleteAccountClick(Account account)
        {
            if (Accounts.Count == 1)
            {
                await DisplayAlert("Espera", "No puedes eliminar la última cuenta. Debe existir al menos una.", "Entendido");
                return;
            }

            if (await DisplayAlert("Cuidado", "Esta acción no se puede deshacer. Seguro que deseas continuar?", "Seguro", "Volver"))
            {
                if (await DbService.Instance.Delete(account))
                {
                    Accounts.Remove(account);
                    await DbService.Instance.Delete<Historical>(model => model.AccountId == account.Id);
                    await DisplayAlert("Genial!", "La cuenta se ha eliminado correctamente", "Entendido");
                }

                if (Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString()) == account.Id.ToString())
                {
                    Preferences.Set(Constants.KEY_CURRENT_ACCOUNT_ID, Accounts.First().Id.ToString());
                }
            }
        }
    }
}
