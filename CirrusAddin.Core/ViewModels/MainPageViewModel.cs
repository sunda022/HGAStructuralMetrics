using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CirrusAddin.Core.Commands;
using CirrusAddin.Core.Helpers;
using CirrusAddin.Core.Models;

namespace CirrusAddin.Core.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ICommand GoToNextPage { get; set; }
        public ICommand GoToPreviousPage { get; set; }
        public bool IsBackButtonEnabled
        {
            get => SelectedTabIndex != 0;
            set { IsBackButtonEnabled = value; }
        }
        public bool IsNextButtonEnabled
        {
            get => SelectedTabIndex != PageViewModels.Count - 1;
            set { IsNextButtonEnabled = value; }
        }

        private List<BasePageViewModel> _pageViewModels;
        public List<BasePageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<BasePageViewModel>();
                return _pageViewModels;
            }
        }

        private BasePageViewModel _currentPageViewModel;
        public BasePageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                CurrentPageViewModel = PageViewModels[_selectedTabIndex];
                OnPropertyChanged("SelectedTabIndex");
                OnPropertyChanged("IsNextButtonEnabled");
                OnPropertyChanged("IsBackButtonEnabled");
            }
        }

        public MainPageViewModel(AddinDataProperties addinDataProperties) : base(addinDataProperties)
        {
            DataProperties = addinDataProperties;
            InitializeCommands();
            PageViewModels.Add(new BlankPageViewModel(DataProperties));
            SelectedTabIndex = 0;
            CurrentPageViewModel = PageViewModels[SelectedTabIndex];
        }

        private void InitializeCommands()
        {
            GoToNextPage = new RouteCommands(() =>
            {
                if (SelectedTabIndex < PageViewModels.Count)
                    SelectedTabIndex++;
            });

            GoToPreviousPage = new RouteCommands(() =>
            {

                if (SelectedTabIndex != 0)
                    SelectedTabIndex--;
            });
        }
    }
}
