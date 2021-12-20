using Autodesk.Revit.UI;
using CirrusAddin.Properties;
using CirrusAddin.UI.RevitUI;

namespace CirrusAddin
{
    public class SetupInterface
    {
        public SetupInterface()
        {

        }
        public void Initialize(UIControlledApplication app)
        {
            // Create ribbon tab.
            string tabName = Resource.RevitTabName;
            app.CreateRibbonTab(tabName);

            // Create the ribbon panels.
            var managerCommandsPanel = app.CreateRibbonPanel(tabName, Resource.RevitPanelName);

            //Creates the button
            var familyManagerShowButtonData = new RevitPushButtonDataModel
            {
                Label = Resource.RevitButtonName,
                Panel = managerCommandsPanel,
                Tooltip = Resource.RevitButtonTooltip,
                CommandNamespacePath = MainDockablePaneShowCommand.GetPath(),
                AssemblyLocation = MainDockablePaneShowCommand.GetAssemblyLocation(),
                IconImageName = "push_button32.png",
                TooltipImageName = "push_button.png"
            };
            //This was a test to create a second button
            /*var familyManagerShowButtonData2 = new RevitPushButtonDataModel
            {
                Label = Resource.RevitButtonName2,
                Panel = managerCommandsPanel,
                Tooltip = Resource.RevitButtonTooltip,
                CommandNamespacePath = MainDockablePaneShowCommand.GetPath(),
                AssemblyLocation = MainDockablePaneShowCommand.GetAssemblyLocation(),
                IconImageName = "push_button32.png",
                TooltipImageName = "push_button.png"
            };*/

            RevitPushButton.Create(familyManagerShowButtonData);
            //RevitPushButton.Create(familyManagerShowButtonData2);

        }

    }
}
