using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace VigicomPlus.ViewModels
{
    public class TimesViewModel : MyBaseViewModel
    {
        public IAsyncCommand BtnSendSmsCommand { get; set; }
        public MvvmHelpers.Commands.Command<string> EdtSirenTextChangedCommand { get; set; }
        public MvvmHelpers.Commands.Command<string> EdtVoiceTextChangedCommand { get; set; }

        public TimesViewModel() { }

        public TimesViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSendSmsCommand = new AsyncCommand(BtnSendSmsClick);
            EdtSirenTextChangedCommand = new MvvmHelpers.Commands.Command<string>(EdtSirenTextChangedClick);
            EdtVoiceTextChangedCommand = new MvvmHelpers.Commands.Command<string>(EdtVoiceTextChangedClick);
            IsBusy = true;
            try
            {
                SirenTime = Preferences.Get(Constants.KEY_TIMES_SIREN, "");
                VoiceTime = Preferences.Get(Constants.KEY_TIMES_VOICE, "");
            }
            catch
            {
                SirenTime = "";
                VoiceTime = "";
            }
        }

        private void EdtSirenTextChangedClick(string newValue)
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

        private void EdtVoiceTextChangedClick(string newValue)
        {
            VoiceTime = VoiceTime.Replace("-", "");
            VoiceTime = VoiceTime.Replace(".", "");
            VoiceTime = VoiceTime.Replace(",", "");
            if (int.TryParse(newValue, out int intValue))
            {
                if (intValue < 0)
                {
                    VoiceTime = "0";
                }

                if (intValue > 255)
                {
                    VoiceTime = "255";
                }
            }
        }

        private async Task BtnSendSmsClick()
        {
            if (sirenTime == string.Empty)
            {
                await DisplayAlert("Campos vacíos", "Debes diligenciar al menos el campo sirena.", "Entendido");
                return;
            }

            IsBusy = false;
            var voice = voiceTime == string.Empty ? "0" : voiceTime;
            if (await Tools.SendSMS("Cambio de data de los tiempos.", "*AP04,{AlarmPassword}," + int.Parse(sirenTime).ToString("D3") + "," + int.Parse(voice).ToString("D3")))
            {
                Preferences.Set(Constants.KEY_TIMES_SIREN, sirenTime);
                Preferences.Set(Constants.KEY_TIMES_VOICE, voiceTime);
            }
            else
            {
                await DisplayAlert("Error", "Clave de programación no configurada.", "Entendido");
            }
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
