using CirrusAddin.Core.Models;
using System.Windows.Input;

namespace CirrusAddin.Core.ViewModels
{
    public class BlankPageViewModel : BaseViewModel, BasePageViewModel
    {
        public BlankPageViewModel(AddinDataProperties addinDataProperties) : base(addinDataProperties)
        {
        }

        public ICommand OnLoaded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
