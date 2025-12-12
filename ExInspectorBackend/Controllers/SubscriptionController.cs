using CommunityToolkit.Datasync.Server;
using CommunityToolkit.Datasync.Server.EntityFrameworkCore;
using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/subscription")]
    public class SubscriptionController : TableController<Subscription>
    {
        public SubscriptionController(AppDbContext context)
            : base(new EntityTableRepository<Subscription>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true };
        }
    }
}
