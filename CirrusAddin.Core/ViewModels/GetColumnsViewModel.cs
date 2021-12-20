using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CirrusAddin.Core.Commands;
using CirrusAddin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CirrusAddin.Core.ViewModels
{
    public class GetColumnsViewModel : BaseViewModel, BasePageViewModel
    {
        public GetColumnsViewModel(AddinDataProperties addinDataProperties) : base(addinDataProperties)
        {
            OnButtonClick = new RouteCommands(async () =>
             {
                 await DataProperties.RvtTask.Run((uiapp) =>
                 {
                     //Gets a list of all the plan views
                     //List<ViewPlan> planViews = RvtUtil.GetViewPlans(uiapp.ActiveUIDocument.Document);

                     //string report = "";
                     //foreach(ViewPlan vp in planViews)
                     //{
                     //    report += "\n" + vp.Name;
                     //}
                     //TaskDialog.Show("Plan Names", report);

                     /// Read all BuiltInCategory.OST_StructuralFraming elements from a Revit model.
                     /// </summary>
                    // var collector = new FilteredElementCollector(uiapp.ActiveUIDocument.Document);
                    // var filterCategory = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
                    // var filterNotSymbol = new ElementClassFilter(typeof(FamilySymbol), true);
                    // var filter = new LogicalAndFilter(filterCategory, filterNotSymbol);
                    // var elements = collector.WherePasses(filter).ToElements();


                     //string report = "";

                     //foreach (var element in elements)
                     //{
                     //    report += "\n" + element.Name;
                     //}

                     //TaskDialog.Show("Plan Names", report);

                 });
             });

        }

        public ICommand OnButtonClick { get; set; }
        public ICommand OnLoaded { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
