using Bl;
using Microsoft.AspNetCore.Mvc;

namespace PHONES_MARKETE.Controllers
{
    public class PagesController : Controller
    {
        IPages oClsPages;
        public PagesController(IPages Pages)
        {
            oClsPages = Pages;
        }


        public IActionResult Index(int id)
        {
            var page = oClsPages.GetById(id);
            return View(page);
        }
       
    }
}
