using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using CirrusAddin.UI.RevitUI;

namespace CirrusAddin
{
    public class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // Initialize whole plugin's user interface.
            var ui = new SetupInterface();
            ui.Initialize(application);

            var familyManagerRegisterCommand = new RegisterMainDockablePaneCommand();
            familyManagerRegisterCommand.Execute(application);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
