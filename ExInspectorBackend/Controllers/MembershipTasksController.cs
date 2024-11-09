using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/membershiptasks")]
    public class MembershipTasksController : TableController<MembershipTasks>
    {
        public MembershipTasksController(AppDbContext context)
            : base(new EntityTableRepository<MembershipTasks>(context))
        {
        }
    }
}