
using Vigicom.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigicom.Pages
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