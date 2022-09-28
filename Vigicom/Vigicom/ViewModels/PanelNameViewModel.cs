using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class PanelNameViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnSendSmsCommand { get; set; }

        public PanelNameViewModel() { }

        public PanelNameViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSendSmsCommand = new AsyncCommand(BtnSendSmsClick);
            IsBusy = true;
            PanelName = Preferences.Get(Constants.KEY_TIMES_SIREN, "");
        }

        private async Task BtnSendSmsClick()
        {
            if (panelName == "")
            {
                await DisplayAlert("Campos vacíos", "Todos los campos deben ser diligenciados.", "Entendido");
                return;
            }

            IsBusy = false;
            await Tools.SendSMS("Cambio de nombre del panel.", "*AP02,{UserPassword}," + panelName);
            Preferences.Set(Constants.KEY_PANEL_NAME, panelName);
            IsBusy = true;
        }

        private string panelName = "";
        public string PanelName
        {
            get => panelName;
            set => SetProperty(ref panelName, value);
        }
    }
}
