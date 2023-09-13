using Microsoft.AspNetCore.Mvc;
using PHONES_MARKETE.Models;
using Bl;

namespace PHONES_MARKETE.Controllers
{
    public class Items : Controller
    {
        IItems oItem;
        
        public Items(IItems items )
        {
            oItem=items;
            

        }
        public IActionResult ItemDetails(int id)
        {
            var item=oItem.GetItemId(id);
            VmItems_ vm = new VmItems_();
            vm.Item = item;
            vm.lstRecommendedItems = oItem.GetRecommendedItems(id).Take(6).ToList();
            vm.lstItemImages = oItem.GetByItemId(id);

            return View(vm);
        }
        public IActionResult ItemList()
        {
            VmItems_ vm = new VmItems_();
            vm.lstAllItems = oItem.GetAllItemsData(null).Take(20).ToList();
          
            return View(vm); 
        }

        public IActionResult ItemsByCatId(int id)
        {
            VmItems_ vm = new VmItems_();
            vm.lstAllItemsByCategoryId = oItem.GetByCatId(id);


            return View(vm);
        }


    }
}
