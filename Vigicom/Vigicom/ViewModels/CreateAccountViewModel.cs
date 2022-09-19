using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {

        public CreateAccountViewModel()
        {
            BtnClear = new Command(OnBtnClearClick);
            BtnSave = new Command(OnBtnSaveClick);
        }

        public CreateAccountViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnClear = new Command(OnBtnClearClick);
            BtnSave = new Command(OnBtnSaveClick);
        }

        private string name = "";
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string simNumber = "";
        public string SimNumber
        {
            get => simNumber;
            set
            {
                simNumber = value;
                OnPropertyChanged();
            }
        }

        private string userPassword = "";
        public string UserPassword
        {
            get => userPassword;
            set
            {
                userPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand BtnClear { get; }

        private void OnBtnClearClick()
        {
            Name = "";
            SimNumber = "";
            UserPassword = "";
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


        }

    }
}
