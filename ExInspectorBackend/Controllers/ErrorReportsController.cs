using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/errorreports")]
    public class ErrorReportsController : TableController<ErrorReports>
    {
        public ErrorReportsController(AppDbContext context)
            : base(new EntityTableRepository<ErrorReports>(context))
        {
        }
    }
}