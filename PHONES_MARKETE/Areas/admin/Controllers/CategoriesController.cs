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
    public class CategoriesController : Controller
    {
        public CategoriesController(ICategories category,IOs oIos)
        {
            oClsCategories = category;
            oClsOs = oIos;
        }
        ICategories oClsCategories;
        IOs oClsOs;
        public IActionResult List()
        {
            return View(oClsCategories.GetAll());

        }
        public IActionResult Edit(int? categoryId)
        {
            ViewBag.lstOs = oClsOs.GetAll();
            var category = new TbCategory();
            if (categoryId != null)
            {
                category = oClsCategories.GetById(Convert.ToInt32(categoryId));
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategory category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", category);

            category.CategoryImage = await Helper.UploadImage(Files, "Categories");

            oClsCategories.Save(category);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int categoryId)
        {
            oClsCategories.Dekete(categoryId);
            return RedirectToAction("List");
        }

        async Task<string> UploadImage(List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/Categories", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }
    }
}
