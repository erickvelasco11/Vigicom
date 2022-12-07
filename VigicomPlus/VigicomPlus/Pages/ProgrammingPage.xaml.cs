
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgrammingPage : ContentPage
    {
        public ProgrammingPage()
        {
            InitializeComponent();
            BindingContext = new ProgrammingViewModel(Navigation);
        }
    }
}