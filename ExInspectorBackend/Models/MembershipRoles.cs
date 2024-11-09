
using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class MembershipRoles : EntityTableData
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

    }
}
