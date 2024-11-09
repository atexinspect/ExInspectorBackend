using Microsoft.AspNetCore.Datasync.EFCore;

namespace ExInspectorBackend.Models
{
    public class Location : EntityTableData
    {
        public string LocationName { get; set; }
        public string Owner { get; set; }

    }
}

