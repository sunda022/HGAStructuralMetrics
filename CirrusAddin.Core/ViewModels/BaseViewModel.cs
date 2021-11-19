using System.ComponentModel;
using System.Windows.Input;
using CirrusAddin.Core.Commands;
using CirrusAddin.Core.Models;

namespace CirrusAddin.Core.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AddinDataProperties _dataProperties;
        public AddinDataProperties DataProperties
        {
            get { return _dataProperties; }
            set
            {
                _dataProperties = value;
                OnPropertyChanged("DataProperties");
            }
        }
        
        public BaseViewModel(AddinDataProperties addinDataProperties)
        {
            DataProperties = addinDataProperties;
        }

        public void OnPropertyChanged(string param)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }
    }
}
