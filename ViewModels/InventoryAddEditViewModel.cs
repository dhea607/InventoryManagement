using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.ViewModels
{
    [Keyless]
    public class InventoryAddEditViewModel
    {
        public int InventoryId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public List<InventoryMediaViewModel>? InventoryMedias { get; set; }
        //public List<InventoryMedia>? InventoryMedias { get; set; }
        public List<InventoryDetailViewModel>? InventoryDetails { get; set; }
    }
}
