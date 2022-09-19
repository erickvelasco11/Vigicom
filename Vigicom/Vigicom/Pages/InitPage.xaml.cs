using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Vigicom.ViewModels;

using Xamarin.Forms;

namespace Vigicom.Pages
{
    public partial class InitPage : ContentPage
    {
        public InitPage()
        {
            InitializeComponent();
            var viewModel = new InitViewModel(Navigation);
            BindingContext = viewModel;

            viewModel.GoToMainPage();
        }
    }
}
