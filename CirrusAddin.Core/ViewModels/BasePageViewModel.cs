using System.Windows.Input;

namespace CirrusAddin.Core.ViewModels
{
    public interface BasePageViewModel
    {
        ICommand OnLoaded { get; set; }
    }
}
