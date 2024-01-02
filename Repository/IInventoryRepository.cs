using InventoryManagement.Models;
using InventoryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Repository
{
    public interface IInventoryRepository
    {
        //Task<Inventory> GetByIdAsync(int Id);
        //Task<List<Inventory>> GetAllAsync();
        //Task AddAsync(Inventory inventory);
        //Task UpdateAsync(Inventory inventory);
        //Task DeleteAsync(int Id);
        public IEnumerable<Inventory> GetAll();
        public List<InventoryListViewModel> GetAllInventory();
        public InventoryAddEditViewModel GetDetails(int inventoryId);
        public IEnumerable<Detail> GetAllDetail();
        public IList<SelectListItem> GetDetailDropdownList();
        public void Add(InventoryAddEditViewModel formData);
        public void Delete(int inventoryId);
    }
}
