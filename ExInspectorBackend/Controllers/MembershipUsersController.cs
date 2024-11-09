using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/membershipusers")]
    public class MembershipUsersController : TableController<MembershipUsers>
    {
        public MembershipUsersController(AppDbContext context)
            : base(new EntityTableRepository<MembershipUsers>(context))
        {
        }
    }
}