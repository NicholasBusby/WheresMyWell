using Xamarin.Forms;
using Wheres_My_Well.ViewModels;
using System.ComponentModel;

namespace Wheres_My_Well.Views
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void Filter_Clicked(object sender, System.EventArgs e)
        {
            WellMap.Pins.Add(new Xamarin.Forms.Maps.Pin() { Position = new Xamarin.Forms.Maps.Position(45, -108), Label = "place", Type = Xamarin.Forms.Maps.PinType.Place });
        }
    }
}
