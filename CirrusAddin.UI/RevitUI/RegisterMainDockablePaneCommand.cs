using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows;
using CirrusAddin.Core.Models;
using CirrusAddin.Core.RvtTasks;
using CirrusAddin.UI.Views;
using CirrusAddin.UI.Properties;

namespace CirrusAddin.UI.RevitUI
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RegisterMainDockablePaneCommand : IExternalCommand
    {
        private readonly RvtTask revitTask = new RvtTask();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Result.Succeeded;
        }

        public Result Execute(UIControlledApplication uIApplication)
        {
            var data = new DockablePaneProviderData();

            AddinDataProperties addinDataProperties = new AddinDataProperties();
            addinDataProperties.SystemUsername = Environment.UserName;
            addinDataProperties.RvtTask = revitTask;

            uIApplication.ViewActivated += addinDataProperties.Application_DocumentSwitched;

            var mainPage = new MainPage(addinDataProperties);

            data.FrameworkElement = mainPage as FrameworkElement;

            var state = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
            };

            var dpid = new DockablePaneId(DockablePaneIdentifiers.GetPaneIdentifier());
            uIApplication.RegisterDockablePane(dpid, Resources.DockablePaneName, mainPage as IDockablePaneProvider);


            return Result.Succeeded;
        }
    }
}
