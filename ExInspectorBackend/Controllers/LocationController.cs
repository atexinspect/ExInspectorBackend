using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/location")]
    public class LocationController : TableController<Location>
    {
        public LocationController(AppDbContext context)
            : base(new EntityTableRepository<Location>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true, PageSize = 5 };
        }
    }
}