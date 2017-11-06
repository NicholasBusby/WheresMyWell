using Xamarin.Forms;
using Wheres_My_Well.ViewModels;
using System.ComponentModel;
using Wheres_My_Well.Services;
using System.Linq;
using System.Collections.Generic;
using Wheres_My_Well.Models;
using Rg.Plugins.Popup.Services;

namespace Wheres_My_Well.Views
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private MainPageViewModel ViewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            BindingContext = ViewModel;
            GetWells();
        }

        private async void GetWells()
        {
            var wells = await ViewModel.GetWells();
            addWellsToMap(wells);
        }

        private async void Filter_Clicked(object sender, System.EventArgs e)
        {
            var wells = await ViewModel.GetWells();
            var filter = new Filter(wells);
            await PopupNavigation.PushAsync(filter, true);
        }

        private void addWellsToMap(IEnumerable<Well> wells)
        {
            WellMap.Pins.Clear();
            var limitedWells = wells.Take(100);
            foreach (var well in limitedWells)
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
    }
}
