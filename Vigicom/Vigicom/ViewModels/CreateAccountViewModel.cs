using MvvmHelpers.Commands;

using System;
using System.Linq;
using System.Windows.Input;

using Vigicom.Models;
using Vigicom.Pages;
using Vigicom.Services;

using Xamarin.Essentials;

namespace Vigicom.ViewModels
{
    public class CreateAccountViewModel : MyBaseViewModel
    {
        private Account CurrentAccount { get; set; }

        public ICommand BtnClearCommand { get; }

        public ICommand BtnSaveCommand { get; }

        public CreateAccountViewModel()
        {
        }

        public CreateAccountViewModel(Xamarin.Forms.INavigation navigation)
        {
            Navigation = navigation;
            BtnClearCommand = new Command(OnBtnClearClick);
            BtnSaveCommand = new Command(OnBtnSaveClick);
        }

        public CreateAccountViewModel(Xamarin.Forms.INavigation navigation, Account account)
        {
            Navigation = navigation;
            BtnClearCommand = new Command(OnBtnClearClick);
            BtnSaveCommand = new Command(OnBtnSaveClick);
            CurrentAccount = account;
            Name = account.Name;
            SimNumber = account.SimNumber;
            UserPassword = account.UserPassword;
        }

        private string name = "";
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string simNumber = "";
        public string SimNumber
        {
            get => simNumber;
            set => SetProperty(ref simNumber, value);
        }

        private string userPassword = "";
        public string UserPassword
        {
            get => userPassword;
            set => SetProperty(ref userPassword, value);
        }

        private void OnBtnClearClick()
        {
            Name = "";
            SimNumber = "";
            UserPassword = "";
        }

        private async void OnBtnSaveClick()
        {
            if (Name == "" || SimNumber == "" || UserPassword == "")
            {
                await DisplayAlert("No se puede guardar", "Debes completar todos los campos", "Entendido");
                return;
            }

            if (SimNumber.Length != 10)
            {
                await DisplayAlert("No se puede guardar", "El número SIM debe ser de 10 dígitos", "Entendido");
                return;
            }

            if (UserPassword.Length != 4)
            {
                await DisplayAlert("No se puede guardar", "La clave del usuario debe ser de 4 dígitos", "Entendido");
                return;
            }

            if (CurrentAccount == null)
            {
                var account = new Account()
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    SimNumber = SimNumber,
                    UserPassword = UserPassword
                };

                account = await DbService.Instance.Add(account);
                if (account != null)
                {
                    Preferences.Set(Constants.KEY_CURRENT_ACCOUNT_ID, account.Id.ToString());
                    await DisplayAlert("Genial!", "La cuenta se ha guardado.", "Entendido");
                    if (Navigation.NavigationStack.Count == 1)
                    {
                        await Navigation.PushAsync(new MainPage());
                        Navigation.RemovePage(Navigation.NavigationStack.First());
                    }
                    else
                    {
                        await Navigation.PopToRootAsync();
                    }
                }
                else
                {
                    await DisplayAlert("Ups!", "No hemos podido guardar la cuenta", "Entendido");
                }
            }
            else
            {
                var account = new Account()
                {
                    Id = CurrentAccount.Id,
                    Name = Name,
                    SimNumber = SimNumber,
                    UserPassword = UserPassword
                };

                if (await DbService.Instance.Edit(account))
                {
                    await DisplayAlert("Genial!", "La cuenta se ha modificado correctamente.", "Entendido");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Ups!", "No hemos podido modificar la cuenta", "Entendido");
                }
            }
        }

    }
}
