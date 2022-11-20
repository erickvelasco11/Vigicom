
using Vigicom.ViewModels;

using Xamarin.Forms;

namespace Vigicom.Pages
{
    public partial class InitPage : ContentPage
    {
        private readonly InitViewModel viewModel;

        public InitPage()
        {
            InitializeComponent();
            viewModel = new InitViewModel(Navigation);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GoToMainPage();
        }
    }
}
