using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Security.Cryptography;
using System.Text;
using CsvHelper;
using Doppelchecker.Models;
using Doppelchecker.ViewModels;
using Doppelchecker.Views;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models.Raw;
using Reactive.Bindings.Extensions;

namespace Doppelchecker
{
    [ExportMetadata("Title", "Doppelchecker")]
    [ExportMetadata("Description", "艦娘の所属状況を表示します。")]
    [ExportMetadata("Version", "0.1.0")]
    [ExportMetadata("Author", "@hgzr")]
    [ExportMetadata("Guid", "E2FBF552-0797-464B-BB01-B39A6571C4F9")]
    [Export(typeof(IPlugin))]
    [Export(typeof(ITool))]
    public class Doppelchecker : IPlugin, ITool
    {
        private ShipListViewModel _viewModel;
        private IDisposable PortSubscribe { get; set; }

        public void Initialize()
        {
            ImportCsv();

            PortSubscribe = KanColleClient.Current.Proxy.api_port.TryParse<kcsapi_port>().Subscribe(x => HomeportSubscription());
        }

        public void ImportCsv()
        {
            _viewModel = new ShipListViewModel();
            _viewModel.Initialize();

            using (var reader = new StreamReader("static\\ShipListMaster.csv", Encoding.UTF8))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap(new ShipMap());

                var records = csv.GetRecords<Ship>();
                foreach (var record in records)
                {
                    var ship = new ShipViewModel();
                    ship.Ship = record;
                    _viewModel.ShipList.Add(ship);
                }
            }
        }

        public void HomeportSubscription()
        {
            if (KanColleClient.Current?.Homeport?.Organization?.Ships == null) return;
            KanColleClient.Current?.Homeport?.Organization.ObserveProperty(x => x.Ships).Subscribe(x => ShipSubscribe(x.Values));
            PortSubscribe.Dispose();
        }

        public void ShipSubscribe(IEnumerable<Grabacr07.KanColleWrapper.Models.Ship> homeportShips)
        {
            var shipViewModels = _viewModel.ShipList.AsEnumerable();
            var splitChar = new[] {'改', '甲', '航'};

            foreach (var ship in homeportShips)
            {
                var shipName = ship.Info.Name;

                // want "pure" ship name so need to delete suffix
                var splitIndex = shipName.IndexOfAny(splitChar);
                // workaround for "Prinz Eugen改"
                splitIndex = splitIndex == -1 ? shipName.IndexOf(' ') : splitIndex;

                var purifiedShipName = splitIndex >= 0 ? shipName.Substring(0, splitIndex) : shipName;
                var shipEnumerable = _viewModel.ShipList.Where(x => x.Ship.ShipName == purifiedShipName).Select(x => x.Ship);
                if (shipEnumerable.Any())
                {
                    shipEnumerable.First().IsMember = true;
                }
            }
        }

        public string Name { get; } = "Doppelchecker";
        public object View => new ShipListView {DataContext = _viewModel};
    }
}
