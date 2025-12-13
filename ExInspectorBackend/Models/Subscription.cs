using CommunityToolkit.Datasync.Server.EntityFrameworkCore;

namespace ExInspectorBackend.Models
{
    public class Subscription : EntityTableData
    {
        public bool IsActive { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsNearExpiration { get; set; }
        public string SkuStoreId { get; set; } = string.Empty;
    }
}
