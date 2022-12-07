
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
            BindingContext = new UsersViewModel(Navigation);
        }
    }
}