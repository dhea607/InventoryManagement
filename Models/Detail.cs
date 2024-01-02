namespace InventoryManagement.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public InventoryDetail InventoryDetail { get; set; }
    }
}
