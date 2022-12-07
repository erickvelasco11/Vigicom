
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertsPage : ContentPage
    {
        public AlertsPage()
        {
            InitializeComponent();
            BindingContext = new AlertsViewModel(Navigation);
        }
    }
}