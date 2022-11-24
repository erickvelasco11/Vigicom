using System.Windows.Input;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class AccountMenuViewModel : MyBaseViewModel
    {
        public Popup Popup { get; set; }
        public ICommand BtnEditCommand { get; set; }
        public ICommand BtnDeleteCommand { get; set; }

        public AccountMenuViewModel(Popup popup, INavigation navigation)
        {
            Popup = popup;
            Navigation = navigation;
            BtnEditCommand = new Command(MenEditAccountClick);
            BtnDeleteCommand = new Command(MenDeleteAccountClick);
        }

        private void MenEditAccountClick()
        {
            Popup.Dismiss("Editar");
        }

        private void MenDeleteAccountClick()
        {
            Popup.Dismiss("Eliminar");
        }
    }
}
