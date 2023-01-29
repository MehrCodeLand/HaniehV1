using Microsoft.AspNetCore.Mvc;

namespace HaniehV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Main() => View();
    }
}
