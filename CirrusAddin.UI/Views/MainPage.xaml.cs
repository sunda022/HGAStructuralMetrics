using Autodesk.Revit.UI;
using CirrusAddin.Core.Models;
using CirrusAddin.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CirrusAddin.UI.Views
{
    public partial class MainPage : Page, IDockablePaneProvider
    {
        public MainPage(AddinDataProperties addinData)
        {
            InitializeComponent();
            DataContext = new MainPageViewModel(addinData);
        }

        public void SetupDockablePane(DockablePaneProviderData dockablePaneData)
        {
            dockablePaneData.VisibleByDefault = false;
            dockablePaneData.FrameworkElement = this as FrameworkElement;
            dockablePaneData.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
            };
        }

        private void label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(@"https://viatechnik.com/");
        }
        

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
