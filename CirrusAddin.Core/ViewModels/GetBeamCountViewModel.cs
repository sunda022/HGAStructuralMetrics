using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CirrusAddin.Core.Commands;
using CirrusAddin.Core.Models;
using CirrusAddin.Core.RvtTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CirrusAddin.Core.ViewModels
{
    public class GetBeamCountViewModel : BaseViewModel, BasePageViewModel
    {

        public GetBeamCountViewModel(AddinDataProperties addinDataProperties) : base(addinDataProperties)
        {
            DataProperties = addinDataProperties;

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
                    //var collector = new FilteredElementCollector(uiapp.ActiveUIDocument.Document);
                    //var filterCategory = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
                    //var filterNotSymbol = new ElementClassFilter(typeof(FamilySymbol), true);
                    //var filter = new LogicalAndFilter(filterCategory, filterNotSymbol);
                    //var elements = collector.WherePasses(filter).ToElements();

                    var filter = RvtUtil.GetElementsByBuiltInCategory(uiapp.ActiveUIDocument.Document, BuiltInCategory.OST_StructuralFraming);
                    string report = "";

                    foreach (var element in filter.ToElements())
                    {
                        report += "\n" + element.Name;
                    }

                    TaskDialog.Show("Beams", report);

                });
            });
        }

        public ICommand OnLoaded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ICommand OnButtonClick { get; set; }
    }



}
