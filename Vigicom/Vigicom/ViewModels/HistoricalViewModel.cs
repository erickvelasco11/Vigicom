
using MvvmHelpers;

using System;
using System.Linq;

using Vigicom.Models;
using Vigicom.Services;

using Xamarin.Essentials;
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
            var currentAccountId = Guid.Parse(Preferences.Get(Constants.KEY_CURRENT_ACCOUNT_ID, Guid.Empty.ToString()));
            var registers = await DbService.Instance.GetAll<Historical>();//.Find<Historical> (model => model.AccountId == currentAccountId);
            if (registers.Count > 0)
            {
                registers = registers.OrderByDescending(model => model.Date).ToList();
                Historical.AddRange(registers);
            }
        }
    }
}
