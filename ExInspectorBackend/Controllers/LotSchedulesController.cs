using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/lotschedules")]
    public class LotSchedulesController : TableController<LotSchedules>
    {
        public LotSchedulesController(AppDbContext context)
            : base(new EntityTableRepository<LotSchedules>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true, PageSize = 25 };
        }
    }
}