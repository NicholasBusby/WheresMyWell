using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        private IEnumerable<IWellService> wellServices;
        private IEnumerable<Well> Wells;

        public MainPageViewModel(IEnumerable<IWellService> wellServices)
        {
            this.wellServices = wellServices;
        }

        public async Task<IEnumerable<Well>> GetWells()
        {
            if((Wells?.Count() ?? 0) == 0)
            {
                var wellTasks = wellServices.Select(x => x.GetWells());
                var wellLists = await Task.WhenAll(wellTasks);
                Wells = wellLists.SelectMany(x => x);
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
