using CsvHelper.Configuration;
using Livet;

namespace Doppelchecker.Models
{
    public class Ship : NotificationObject
    {
        #region ShipClassName変更通知プロパティ
        private string _shipClassName;

        /// <summary>
        /// 艦種名
        /// </summary>
        public string ShipClassName
        {
            get
            { return _shipClassName; }
            set
            {
                if (_shipClassName == value)
                    return;
                _shipClassName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ShipTypeName変更通知プロパティ
        private string _shipTypeName;

        /// <summary>
        /// 艦型名
        /// </summary>
        public string ShipTypeName
        {
            get
            { return _shipTypeName; }
            set
            {
                if (_shipTypeName == value)
                    return;
                _shipTypeName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ShipTypeNumber変更通知プロパティ
        private int _shipTypeNumber;

        /// <summary>
        /// 艦型内番号
        /// </summary>
        public int ShipTypeNumber
        {
            get
            { return _shipTypeNumber; }
            set
            {
                if (_shipTypeNumber == value)
                    return;
                _shipTypeNumber = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ShipName変更通知プロパティ
        private string _shipName;

        /// <summary>
        /// 艦名
        /// </summary>
        public string ShipName
        {
            get
            { return _shipName; }
            set
            {
                if (_shipName == value)
                    return;
                _shipName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsImplemented変更通知プロパティ
        private bool _isImplemented;

        /// <summary>
        /// 実装フラグ
        /// </summary>
        public bool IsImplemented
        {
            get
            { return _isImplemented; }
            set
            {
                if (_isImplemented == value)
                    return;
                _isImplemented = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMember変更通知プロパティ
        private bool _isMember;

        /// <summary>
        /// 所属フラグ
        /// </summary>
        public bool IsMember
        {
            get
            { return _isMember; }
            set
            {
                if (_isMember == value)
                    return;
                _isMember = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }

    public sealed class ShipMap : CsvClassMap<Ship>
    {
        public ShipMap()
        {
            Map(m => m.ShipClassName).Index(0);
            Map(m => m.ShipTypeName).Index(1);
            Map(m => m.ShipTypeNumber).Index(2);
            Map(m => m.ShipName).Index(3);
            Map(m => m.IsImplemented).Index(4);
        }
    }
}
