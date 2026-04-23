using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
