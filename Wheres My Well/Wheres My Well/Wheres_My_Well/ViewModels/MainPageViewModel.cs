using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Wheres_My_Well.Models;
using Wheres_My_Well.Services;

namespace Wheres_My_Well.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        private string filterButtonText = "Filter";
        public string FilterButtonText
        {
            get
            {
                return filterButtonText;
            }
            set
            {
                filterButtonText = value;
                OnPropertyChanged("FilterButtonText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private NorthDakotaWellService wellService;
        private List<Well> Wells;

        public MainPageViewModel(NorthDakotaWellService wellService)
        {
            this.wellService = wellService;
        }

        public async Task<List<Well>> GetWells()
        {
            if((Wells?.Count ?? 0) == 0)
            {
                Wells = await wellService.GetWells();
            }
            return Wells;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
