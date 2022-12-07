
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
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