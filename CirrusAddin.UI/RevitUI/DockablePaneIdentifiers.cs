using CirrusAddin.UI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirrusAddin.UI.RevitUI
{
    public class DockablePaneIdentifiers
    {
        public static Guid GetPaneIdentifier()
        {
            return new Guid(Resources.DockablePaneGUID);
        }
    }
}
