using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;

namespace InventoryManagement.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryContext _dbContext;
        private string folderPath = "wwwroot/InventoryMedia/Images/";
        public InventoryRepository(InventoryContext inventoryContext)
        {
            this._dbContext = inventoryContext;
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _dbContext.Inventories.Where(x => x.DeletedAt == null);
        }

        public Inventory GetInventoryById(int inventoryId)
        {
            return _dbContext.Inventories.Where(x => x.InventoryId == inventoryId && x.DeletedAt == null).Single();
        }
        public IEnumerable<InventoryMedia> GetInventoryMedias(int inventoryId)
        {
            return _dbContext.InventoryMedias.Where(x=>x.InventoryID == inventoryId && x.DeletedAt == null);
        }

        public IEnumerable<InventoryDetail> GetInventoryDetails(int inventoryId)
        {
            return _dbContext.InventoryDetails.Where(x => x.InventoryID == inventoryId && x.DeletedAt == null).Include("Detail");
        }

        //public string GetDetailNameById(int detailId)
        //{
        //    return _dbContext.Details.Where(x => x.DetailId == detailId && x.DeletedAt == null).Select(c => c.Name).SingleOrDefault();
        //}

        public List<InventoryListViewModel> GetAllInventory()
        {

            var allInventory = _dbContext.Inventories.Where(x => x.DeletedAt == null);
            var inventoryVMList = new List<InventoryListViewModel>();
            foreach (var item in allInventory)
            {
                var inventoryVM = new InventoryListViewModel() {

                    Id = item.InventoryId,
                    Name = item.Name,
                    Code = item.Code
                };
                inventoryVMList.Add(inventoryVM);
            }

            return inventoryVMList;
        }

        public InventoryAddEditViewModel GetDetails(int inventoryId)
        {

            var inventoryVM = new InventoryAddEditViewModel() { };

            //populate inventory
            var inventory = GetInventoryById(inventoryId);
            inventoryVM.InventoryId = inventoryId;
            inventoryVM.Name = inventory.Name;
            inventoryVM.Code = inventory.Code;
            inventoryVM.InventoryMedias = new List<InventoryMediaViewModel>();
            inventoryVM.InventoryDetails = new List<InventoryDetailViewModel>();

            //populate details
            var details = GetInventoryDetails(inventoryId);
            foreach (var item in details)
            {
                var detail = new InventoryDetailViewModel()
                {
                    InventoryDetailId = item.InventoryDetailId,
                    DetailId = item.DetailID,
                    DetailValue = item.Value,
                    DetailName = item.Detail.Name
                };
                inventoryVM.InventoryDetails.Add(detail);
            }

            //populate medias
            var medias = GetInventoryMedias(inventoryId);
            foreach (var item in medias)
            {
                var media = new InventoryMediaViewModel()
                {
                    InventoryMediaId = item.InventoryMediaId
                };
                Byte[] bytes = File.ReadAllBytes(item.FilePath);
                string fileBase64 = Convert.ToBase64String(bytes);
                media.MediaFile = $"data:{item.Type}/{item.FileExtension};base64,{fileBase64}"; 
                inventoryVM.InventoryMedias.Add(media);
            }

            return inventoryVM;
        }

        public IEnumerable<Detail> GetAllDetail()
        {
            return _dbContext.Details.Where(x => x.DeletedAt == null);
        }

        public IList<SelectListItem> GetDetailDropdownList()
        {
            var detail = GetAllDetail().Select(o => new { Text = o.Name, Value = o.DetailId });
            IList<SelectListItem> ddl = new List<SelectListItem>();
            foreach (var item in detail)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Text = item.Text,
                    Value = item.Value.ToString()
                };

                ddl.Add(listItem);
            }
            return ddl;
        }

        public void Add(InventoryAddEditViewModel formData)
        {
            int inventoryId = AddInventory(formData.Code, formData.Name);

            if(formData.InventoryDetails != null)
            {
                AddDetail(inventoryId, formData.InventoryDetails);
            }

            if(formData.InventoryMedias != null)
            {
                AddMedia(inventoryId, formData.InventoryMedias);
            }

        }

        public int AddInventory(string code, string name) 
        {
            var inventory = new Inventory()
            {
                Code = code,
                Name = name,
                CreatedAt = DateTime.Now
            };

            _dbContext.Add(inventory);
            _dbContext.SaveChanges();
            return inventory.InventoryId;
        }

        public void AddDetail(int inventoryId, List<InventoryDetailViewModel> details)
        {
            foreach (var item in details)
            {
                var inventoryDetail = new InventoryDetail() {
                InventoryID = inventoryId,
                DetailID = item.DetailId,
                Value = item.DetailValue,
                CreatedAt= DateTime.Now
                };
                _dbContext.Add(inventoryDetail);
                _dbContext.SaveChanges();
            }        
        }

        public void AddMedia(int inventoryId, List<InventoryMediaViewModel> medias)
        {
            foreach (var item in medias)
            {

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string fileExtension = GetFileExtension(item.MediaFile);
                string filePath = folderPath + inventoryId.ToString() + "-" + fileName + "." + fileExtension;

                var media = new InventoryMedia() {
                    InventoryID = inventoryId,
                    Type = "image",
                    FilePath = filePath,
                    FileName = fileName,
                    FileExtension = fileExtension,
                    CreatedAt = DateTime.Now
                };

                _dbContext.Add(media);
                _dbContext.SaveChanges();

                File.WriteAllBytes(filePath, Convert.FromBase64String(item.MediaFile));
            }
        }

        public string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }

        public void Delete(int inventoryId)
        {
            var inventory = GetInventoryById(inventoryId);
            inventory.DeletedAt = DateTime.Now;

            var details = GetInventoryDetails(inventoryId);
            foreach (var item in details)
            {
                item.DeletedAt = DateTime.Now;
            }

            var media = GetInventoryMedias(inventoryId);
            foreach (var item in media)
            {
                item.DeletedAt = DateTime.Now;
                if ((File.Exists(item.FilePath)))
                {
                    File.Delete(item.FilePath);
                }
            }

            _dbContext.SaveChanges();

        }
    }
}
