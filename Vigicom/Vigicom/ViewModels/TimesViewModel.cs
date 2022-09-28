using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class TimesViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnSendSmsCommand { get; set; }
        public IAsyncCommand<string> EdtSirenTextChangedCommand { get; set; }
        public IAsyncCommand<string> EdtVoiceTextChangedCommand { get; set; }

        public TimesViewModel() { }

        public TimesViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSendSmsCommand = new AsyncCommand(BtnSendSmsClick);
            EdtSirenTextChangedCommand = new AsyncCommand<string>(EdtSirenTextChangedClick);
            EdtVoiceTextChangedCommand = new AsyncCommand<string>(EdtVoiceTextChangedClick);
            IsBusy = true;
            SirenTime = Preferences.Get(Constants.KEY_TIMES_SIREN, "");
            VoiceTime = Preferences.Get(Constants.KEY_TIMES_VOICE, "");
        }

        private async Task EdtSirenTextChangedClick(string newValue)
        {
            SirenTime = SirenTime.Replace("-", "");
            SirenTime = SirenTime.Replace(".", "");
            SirenTime = SirenTime.Replace(",", "");
            if (int.TryParse(newValue, out int intValue))
            {
                if (intValue < 0)
                {
                    SirenTime = "0";
                }

                if (intValue > 255)
                {
                    SirenTime = "255";
                }
            }
        }

        private async Task EdtVoiceTextChangedClick(string newValue)
        {
            SirenTime = SirenTime.Replace("-", "");
            SirenTime = SirenTime.Replace(".", "");
            SirenTime = SirenTime.Replace(",", "");
            if (int.TryParse(newValue, out int intValue))
            {
                if (intValue < 0)
                {
                    SirenTime = "0";
                }

                if (intValue > 99)
                {
                    SirenTime = "99";
                }
            }
        }

        private async Task BtnSendSmsClick()
        {
            if (sirenTime == "" || voiceTime == "")
            {
                await DisplayAlert("Campos vacíos", "Todos los campos deben ser diligenciados.", "Entendido");
                return;
            }

            IsBusy = false;
            await Tools.SendSMS("Cambio de data de los tiempos.", "*AP04,{UserPassword}," + sirenTime + "," + voiceTime);
            Preferences.Set(Constants.KEY_TIMES_SIREN, sirenTime);
            Preferences.Set(Constants.KEY_TIMES_VOICE, voiceTime);
            IsBusy = true;
        }

        private string sirenTime = "";
        public string SirenTime
        {
            get => sirenTime;
            set => SetProperty(ref sirenTime, value);
        }

        private string voiceTime = "";
        public string VoiceTime
        {
            get => voiceTime;
            set => SetProperty(ref voiceTime, value);
        }
    }
}
