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
        public MvvmHelpers.Commands.Command<string> EdtSirenTextChangedCommand { get; set; }
        public Xamarin.Forms.Command<string> EdtVoiceTextChangedCommand { get; set; }

        public TimesViewModel() { }

        public TimesViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BtnSendSmsCommand = new AsyncCommand(BtnSendSmsClick);
            EdtSirenTextChangedCommand = new MvvmHelpers.Commands.Command<string>(EdtSirenTextChangedClick);
            EdtVoiceTextChangedCommand = new Xamarin.Forms.Command<string>(EdtVoiceTextChangedClick);
            IsBusy = true;
            SirenTime = Preferences.Get(Constants.KEY_TIMES_SIREN, 0);
            VoiceTime = Preferences.Get(Constants.KEY_TIMES_VOICE, 0);
        }

        private void EdtSirenTextChangedClick(string newValue)
        {
            if (int.TryParse(newValue, out int intValue))
            {
                if (intValue < 0)
                {
                    SirenTime = 0;
                }

                if (intValue > 255)
                {
                    SirenTime = 255;
                }
            }
        }

        private void EdtVoiceTextChangedClick(string newValue)
        {
            if (int.TryParse(newValue, out int intValue))
            {
                if (intValue < 0)
                {
                    SirenTime = 0;
                }

                if (intValue > 255)
                {
                    SirenTime = 255;
                }
            }
        }

        private async Task BtnSendSmsClick()
        {
            if (sirenTime == 0)
            {
                await DisplayAlert("Campos vacíos", "Debes diligenciar al menos el campo sirena.", "Entendido");
                return;
            }

            IsBusy = false;
            if (await Tools.SendSMS("Cambio de data de los tiempos.", "*AP04,{AlarmPassword}," + sirenTime.ToString("D3") + "," + voiceTime.ToString("D3")))
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

        private int sirenTime = 0;
        public int SirenTime
        {
            get => sirenTime;
            set => SetProperty(ref sirenTime, value);
        }

        private int voiceTime = 0;
        public int VoiceTime
        {
            get => voiceTime;
            set => SetProperty(ref voiceTime, value);
        }
    }
}
