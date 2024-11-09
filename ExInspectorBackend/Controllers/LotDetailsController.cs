using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/lotdetails")]
    public class LotDetailsController : TableController<LotDetails>
    {
        public LotDetailsController(AppDbContext context)
            : base(new EntityTableRepository<LotDetails>(context))
        {
        }
    }
}