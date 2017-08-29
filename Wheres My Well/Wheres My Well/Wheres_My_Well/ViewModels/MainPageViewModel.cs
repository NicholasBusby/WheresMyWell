using System.ComponentModel;

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
