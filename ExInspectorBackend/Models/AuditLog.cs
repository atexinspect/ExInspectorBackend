using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class AuditLog : EntityTableData
    {
        public DateTimeOffset DateTimeIn { get; set; }
        public string AssetID { get; set; }
        public string LoggedOnUser { get; set; }
        public string AppName { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public string OS { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string SiteID { get; set; }
        public string Comments { get; set; }

    }
}
