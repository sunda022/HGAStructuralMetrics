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
            RevitPushButton.Create(familyManagerShowButtonData);
        }

    }
}
