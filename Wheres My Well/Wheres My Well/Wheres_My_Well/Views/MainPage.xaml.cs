using Xamarin.Forms;
using Wheres_My_Well.ViewModels;
using System.ComponentModel;
using Wheres_My_Well.Services;
using System.Linq;

namespace Wheres_My_Well.Views
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        MainPageViewModel ViewModel;
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel(new NorthDakotaWellService());
            BindingContext = ViewModel;
            GetWells();
        }

        private async void GetWells()
        {
            var wells = await ViewModel.GetWells();
            var limitedWells = wells.Take(100);
            foreach(var well in limitedWells)
            {
                var pin = new Xamarin.Forms.Maps.Pin()
                {
                    Position = new Xamarin.Forms.Maps.Position(well.Latitude, well.Longitude),
                    Label = well.WellName,
                    Type = Xamarin.Forms.Maps.PinType.SearchResult
                };
                WellMap.Pins.Add(pin);
            }
        }

        private void Filter_Clicked(object sender, System.EventArgs e)
        {
        }
    }
}
