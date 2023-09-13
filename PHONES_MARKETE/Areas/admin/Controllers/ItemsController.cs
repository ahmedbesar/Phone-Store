using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PHONES_MARKETE.Utlities;
using System.Data;

namespace PHONES_MARKETE.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin,Data Entry")]
    public class ItemsController : Controller
    {
        public ItemsController(IItems item, ICategories category,IOs os)
         
        {
            oClsItems = item;
            oClsCategories = category;
            oClsOs = os;
         
        }
        IItems oClsItems;
        ICategories oClsCategories;
        IOs oClsOs;
      

      
        public IActionResult List()
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItems.GetAllItemsData(null);
            return View(items);
        }




        public IActionResult Edit(int? itemId)
        {
            var item = new TbItem();
            ViewBag.lstCategories = oClsCategories.GetAll();
            
            ViewBag.lstOs = oClsOs.GetAll();
            if (itemId != null)
            {
                item = oClsItems.GetById(Convert.ToInt32(itemId));
            }
            return View(item);
        }

        public IActionResult Search(int id)
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItems.GetAllItemsData(id);
            return View("List", items);
        }

       
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem item, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", item);

            item.ImageName = await Helper.UploadImage(Files, "Items");

            oClsItems.Save(item);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int itemId)
        {
            oClsItems.Dekete(itemId);
            return RedirectToAction("List");
        }



    }
}
