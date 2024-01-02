namespace InventoryManagement.Models
{
    public class InventoryDetail
    {
        public int InventoryDetailId { get; set; }
        public int InventoryID { get; set; }
        public  int DetailID { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
        public Detail Detail { get; set; }
        public Inventory Inventory { get; set; }
    }
}
