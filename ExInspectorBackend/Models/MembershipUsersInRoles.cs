
using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class MembershipUsersInRoles : EntityTableData
    {
        public string UserID { get; set; }
        public string RoleID { get; set; }

    }
}
