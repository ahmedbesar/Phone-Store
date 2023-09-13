using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PHONES_MARKETE.Areas.admin.Controllers
{
    [Area("admin")]
     [Authorize(Roles = "Admin,Data Entry")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
