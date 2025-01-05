using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/assettype")]
    public class AssetTypeController : TableController<AssetType>
    {
        public AssetTypeController(AppDbContext context)
            : base(new EntityTableRepository<AssetType>(context))
        {
            Options = new TableControllerOptions { EnableSoftDelete = true };
        }
    }
}