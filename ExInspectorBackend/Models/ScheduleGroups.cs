
using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class ScheduleGroups : EntityTableData
    {
        public string ScheduleGroupCode { get; set; }
        public string ScheduleGroupName { get; set; }

    }
}
