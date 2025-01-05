using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/locationsystems")]
    public class LocationSystemsController : TableController<LocationSystems>
    {
        public LocationSystemsController(AppDbContext context)
            : base(new EntityTableRepository<LocationSystems>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true };
        }
    }
}