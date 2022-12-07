
using VigicomPlus.Models;
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
            BindingContext = new CreateAccountViewModel(Navigation);
        }
        public CreateAccountPage(Account account)
        {
            InitializeComponent();
            Title = "Editar cuenta";
            BindingContext = new CreateAccountViewModel(Navigation, account);
        }
    }
}