using Core.Servises.AdminSer;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HaniehV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        private readonly IAdminService _admin;
        public AdminHomeController( IAdminService admin)
        {
            _admin = admin;
        }


        public IActionResult Main() => View();


        [Route("Upload")]
        public IActionResult Upload() => View();

        [Route("Upload")]
        [HttpPost]
        public IActionResult Upload(UploadVm upload )
        {
            ViewBag.IsCorrect = _admin.CheckPaint(upload);
            if(ViewBag.IsCorrect != true)
            {
                return View();
            }
            // time to add Paint

            return View(upload);
        }
    }
}
