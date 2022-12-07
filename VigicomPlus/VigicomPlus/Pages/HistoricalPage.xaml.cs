
using VigicomPlus.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VigicomPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricalPage : ContentPage
    {
        public HistoricalPage()
        {
            InitializeComponent();
            BindingContext = new HistoricalViewModel(Navigation);
        }
    }
}