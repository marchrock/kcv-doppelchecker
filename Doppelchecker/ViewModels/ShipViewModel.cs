using Livet;
using Doppelchecker.Models;

namespace Doppelchecker.ViewModels
{
    public class ShipViewModel : ViewModel
    {
        public void Initialize()
        {
        }

        #region Ship変更通知プロパティ
        private Ship _ship;

        public Ship Ship
        {
            get
            { return _ship; }
            set
            {
                if (_ship == value)
                    return;
                _ship = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
