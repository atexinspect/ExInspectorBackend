using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/workorders")]
    public class WorkOrdersController : TableController<WorkOrders>
    {
        public WorkOrdersController(AppDbContext context)
            : base(new EntityTableRepository<WorkOrders>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true };
        }
    }
}