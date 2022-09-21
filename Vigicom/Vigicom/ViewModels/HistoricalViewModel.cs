
using MvvmHelpers;

using Vigicom.Models;
using Vigicom.Services;

using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class HistoricalViewModel : MyBaseViewModel
    {
        public ObservableRangeCollection<Historical> Historical { get; set; }

        public HistoricalViewModel() { }

        public HistoricalViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Historical = new ObservableRangeCollection<Historical>();
            Init();
        }

        private async void Init()
        {
            var registers = await DbService.Instance.GetAll<Historical>();
            Historical.AddRange(registers);
        }


    }
}
