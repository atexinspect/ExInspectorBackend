
using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class AssetType : EntityTableData
    {
        public string AssetTypes { get; set; }
        public string Owner { get; set; }

    }
}
