using Bl;
using Microsoft.AspNetCore.Mvc;
using PHONES_MARKETE.Models;
using System.Diagnostics;
using System.Runtime;

namespace PHONES_MARKETE.Controllers
{
    public class HomeController : Controller
    {
        IItems oClsItems;
        ISliders oClsslider;
        ICategories oClsCategories;
       

        public HomeController(IItems item, ISliders oSlider, ICategories oICategories)
        {
            oClsItems = item;
            oClsslider = oSlider;
            oClsCategories = oICategories;
          
        }


        public IActionResult Index()
        {
            VmHomePage vm = new VmHomePage();
            vm.lstAllItems = oClsItems.GetAllItemsData(null).Take(20).ToList();
            vm.lstRecommendedItems = oClsItems.GetAllItemsData(null).Skip(2).Take(16).ToList();
            vm.lstNewItems = oClsItems.GetAllItemsData(null).Skip(7).Take(16).ToList();
            vm.lstBestSellers = oClsItems.GetAllItemsData(null).Skip(5).Take(16).ToList();
            
            vm.lstSliders = oClsslider.GetAll();
            vm.lstCategories = oClsCategories.GetAll().Take(8).ToList();
          
            return View(vm);
        }

       
    }
}