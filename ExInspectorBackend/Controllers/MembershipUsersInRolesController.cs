using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/membershipusersinroles")]
    public class MembershipUsersInRolesController : TableController<MembershipUsersInRoles>
    {
        public MembershipUsersInRolesController(AppDbContext context)
            : base(new EntityTableRepository<MembershipUsersInRoles>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true, PageSize = 25 };
        }
    }
}