
using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class MembershipTasks : EntityTableData
    {
        public string RolesRequiredForTask { get; set; }
        public string Description { get; set; }

    }
}
