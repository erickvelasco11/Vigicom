using MvvmHelpers;

using Vigicom.Models;
using Vigicom.ViewModels;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace Vigicom.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountMenuPopup : Popup
    {
        public AccountMenuPopup()
        {
            InitializeComponent();
            BindingContext = new AccountMenuViewModel(this, Navigation);
        }
    }
}