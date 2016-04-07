using Livet;
using Doppelchecker.Models;

namespace Doppelchecker.ViewModels
{
    public class ShipListViewModel : ViewModel
    {
        public void Initialize()
        {
            ShipList = new ObservableSynchronizedCollection<ShipViewModel>();
        }

        #region ShipList変更通知プロパティ
        private ObservableSynchronizedCollection<ShipViewModel> _shipList;

        public ObservableSynchronizedCollection<ShipViewModel> ShipList
        {
            get
            { return _shipList; }
            set
            {
                if (_shipList == value)
                    return;
                _shipList = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
