using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class InventoryDetailViewModel
    {
        public int InventoryDetailId { get; set; }
        public int DetailId { get; set; }
        public string? DetailName { get; set; }
        public string? DetailValue { get; set; }
        public Detail Detail { get; set; }
    }
}
