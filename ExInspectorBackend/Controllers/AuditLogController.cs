using ExInspectorBackend.Models;
using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace ExInspectorBackend.Controllers
{
    [Route("tables/auditlog")]
    public class AuditLogController : TableController<AuditLog>
    {
        public AuditLogController(AppDbContext context)
            : base(new EntityTableRepository<AuditLog>(context))
        {
        }
    }
}