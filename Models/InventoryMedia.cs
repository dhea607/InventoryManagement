using System.Security.Principal;

namespace InventoryManagement.Models
{
    public class InventoryMedia
    {
        public int InventoryMediaId { get; set; }
        public  int InventoryID { get; set; }
        public  string? Type { get; set; }
        public  string? FilePath { get; set; }
        public  string? FileName { get; set; }
        public  string? FileExtension { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
        public Inventory Inventory { get; set; }

    }
}
