using InventoryManagement.Repository;
using InventoryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace InventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;

        private const string folderPath = "/InventoryMedia/Images/";

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }
        public IActionResult Index()
        {
            var inventories = _inventoryRepository.GetAllInventory();
            return View(inventories);
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete(int Id) 
        {
            _inventoryRepository.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var details = _inventoryRepository.GetDetails(Id);

            return View(details);
        }

        public IActionResult Details(int Id)
        {
            var details = _inventoryRepository.GetDetails(Id);

            return View(details);
        }

        [HttpGet] 
        public JsonResult GetDropdownListDetail()
        {
            var detail = _inventoryRepository.GetDetailDropdownList();
            return Json(detail);
        }

        [HttpPost]
        public JsonResult AddInventory(InventoryAddEditViewModel formData) {
            try
            {
                _inventoryRepository.Add(formData);
                return Json(new { success = "true", message = "Succesfully add new inventory" });
            }
            catch (Exception e){

                return Json(new { success = "false", message = "Failed to add new inventory - " + e.Message});
            }
        }

        
    }
}
