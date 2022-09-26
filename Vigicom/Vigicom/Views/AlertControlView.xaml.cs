
using Vigicom.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vigicom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertControlView : Grid
    {
        public static readonly BindableProperty AlertProperty = BindableProperty.Create(nameof(Alert), typeof(Alert), typeof(AlertControlView), new Alert(), BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(AlertControlView), "");

        public AlertControlView()
        {
            InitializeComponent();
        }

        public Alert Alert
        {
            get { return (Alert)GetValue(AlertProperty); }
            set { SetValue(AlertProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
    }
}