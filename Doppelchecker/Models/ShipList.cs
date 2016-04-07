using Livet;

namespace Doppelchecker.Models
{
    public class ShipList : NotificationObject
    {
        public ShipList()
        {
            _ship = new ObservableSynchronizedCollection<Ship>();
        }

        #region Ships変更通知プロパティ
        private ObservableSynchronizedCollection<Ship> _ship;

        public ObservableSynchronizedCollection<Ship> Ship
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

        public Ship this[int i]
        {
            set { Ship[i] = value; }
            get { return Ship[i]; }
        }
    }
}
