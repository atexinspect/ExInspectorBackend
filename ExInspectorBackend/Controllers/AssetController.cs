using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/asset")]
    public class AssetController : TableController<Asset>
    {
        public AssetController(AppDbContext context)
            : base(new EntityTableRepository<Asset>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true };
        }
    }
}