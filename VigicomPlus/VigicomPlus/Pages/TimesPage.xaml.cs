
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesPage : ContentPage
    {
        public TimesPage()
        {
            InitializeComponent();
            BindingContext = new TimesViewModel(Navigation);
        }
    }
}