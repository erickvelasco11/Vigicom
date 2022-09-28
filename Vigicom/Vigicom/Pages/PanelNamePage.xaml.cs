
using Vigicom.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigicom.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PanelNamePage : ContentPage
    {
        public PanelNamePage()
        {
            InitializeComponent();
            BindingContext = new PanelNameViewModel(Navigation);
        }
    }
}