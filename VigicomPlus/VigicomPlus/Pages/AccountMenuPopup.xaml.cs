using MvvmHelpers;

using VigicomPlus.Models;
using VigicomPlus.ViewModels;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
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