using MvvmHelpers;

using System.Threading.Tasks;

using Xamarin.Forms;

namespace VigicomPlus.ViewModels
{
    public class MyBaseViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
