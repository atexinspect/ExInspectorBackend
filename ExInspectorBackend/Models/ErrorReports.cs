
using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class ErrorReports : EntityTableData
    {
        public DateTimeOffset DateTimeIn { get; set; }
        public string ErrorCode { get; set; }
        public string LoggedOnUser { get; set; }
        public string AppName { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public string OS { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

    }
}
