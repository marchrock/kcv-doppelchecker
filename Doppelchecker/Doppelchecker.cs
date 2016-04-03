using System.ComponentModel.Composition;
using Grabacr07.KanColleViewer.Composition;

namespace Doppelchecker
{
    [ExportMetadata("Title", "Doppelchecker")]
    [ExportMetadata("Description", "艦娘の所属状況を表示します。")]
    [ExportMetadata("Version", "0.1.0")]
    [ExportMetadata("Author", "@hgzr")]
    [ExportMetadata("Guid", "E2FBF552-0797-464B-BB01-B39A6571C4F9")]
    [Export(typeof(IPlugin))]
    public class Doppelchecker : IPlugin
    {
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
