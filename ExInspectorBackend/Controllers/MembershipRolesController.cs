using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/membershiproles")]
    public class MembershipRolesController : TableController<MembershipRoles>
    {
        public MembershipRolesController(AppDbContext context)
            : base(new EntityTableRepository<MembershipRoles>(context))
        {
        }
    }
}