using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Autodesk.Revit.UI;
using CirrusAddin.Core.Commands;
using CirrusAddin.Core.Helpers;
using CirrusAddin.Core.Models;

namespace CirrusAddin.Core.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
       public ICommand OnButtonClick { get; set; }
        //public ICommand OnButtonClicky { get; set; }
        public ICommand GoToNextPage { get; set; }
        public ICommand GoToPreviousPage { get; set; }
        public bool IsBackButtonEnabled { get; set; } = true;
        public bool IsNextButtonEnabled { get; set; } = true;

        private string _buttonText;


        public string ButtonText
        {
            get
            {
                if (_buttonText == null)
                    _buttonText = "Click Me";
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");
            }
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
                //OnPropertyChanged("IsNextButtonEnabled");
                //OnPropertyChanged("IsBackButtonEnabled");
            }
        }

        public MainPageViewModel(AddinDataProperties addinDataProperties) : base(addinDataProperties)
        {
            this.ButtonText = "Click ME PLZ!";

            DataProperties = addinDataProperties;
            InitializeCommands();
            PageViewModels.Add(new BlankPageViewModel(DataProperties));
            PageViewModels.Add(new GetBeamCountViewModel(DataProperties));
            PageViewModels.Add(new GetColumnsViewModel(DataProperties));
            //PageViewModels.Add(new GetMoreBeamsViewModel(DataProperties));

            SelectedTabIndex = 0;
            CurrentPageViewModel = PageViewModels[SelectedTabIndex];
        }

        private void InitializeCommands()
        {
            OnButtonClick = new RouteCommands(() =>
            {
                TaskDialog.Show("test", "Hello World!");
                this.ButtonText = "CLICKED!";
            });

            GoToNextPage = new RouteCommands(() =>
            {
                
            });

            GoToPreviousPage = new RouteCommands(() =>
            {

                
            });
        }
    }
}
