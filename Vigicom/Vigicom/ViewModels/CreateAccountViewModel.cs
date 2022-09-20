using MvvmHelpers;
using MvvmHelpers.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Vigicom.Models;
using Vigicom.Pages;
using Vigicom.Services;

using Xamarin.Essentials;

namespace Vigicom.ViewModels
{
    public class CreateAccountViewModel : MyBaseViewModel
    {

        public CreateAccountViewModel()
        {
            BtnClear = new Command(OnBtnClearClick);
            BtnSave = new Command(OnBtnSaveClick);
        }

        public CreateAccountViewModel(Xamarin.Forms.INavigation navigation)
        {
            Navigation = navigation;
            BtnClear = new Command(OnBtnClearClick);
            BtnSave = new Command(OnBtnSaveClick);
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

        public ICommand BtnClear { get; }

        private void OnBtnClearClick()
        {
            Name = "";
            SimNumber = "";
            UserPassword = "";
            Title = "LOL";
        }

        public ICommand BtnSave { get; }

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

            var account = new Account()
            {
                Name = Name,
                SimNumber = SimNumber,
                UserPassword = UserPassword
            };

            account = await AccountService.Instance.AddAccount(account);
            if (account != null)
            {
                Preferences.Set(Constants.KEY_CURRENT_ACCOUNT_ID, account.Id.ToString());
                await DisplayAlert("Genial!", "La cuenta se ha guardado.", "Gracias");
                await Navigation.PushAsync(new MainPage());
                Navigation.RemovePage(Navigation.NavigationStack.First());
            }
            else
            {
                await DisplayAlert("Ups!", "No hemos podido guardar la cuenta", "Rayos");
            }
        }

    }
}
