using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Vigicom.ViewModels
{
    public class ProgrammingViewModel : MyBaseViewModel
    {
        public ProgrammingViewModel() { }

        public ProgrammingViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
