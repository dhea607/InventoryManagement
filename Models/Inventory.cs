namespace InventoryManagement.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
        public ICollection<InventoryMedia>? InventoryMedias { get; set; }
        public ICollection<InventoryDetail>? InventoryDetails { get; set; }

    }
}
