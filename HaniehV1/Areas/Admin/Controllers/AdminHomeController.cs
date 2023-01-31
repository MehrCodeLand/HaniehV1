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


        #region Upload

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
            _admin.AddPaint(upload);
            ViewBag.IsAdd = _admin.CheckPaint(upload);
            return View();
        }

        #endregion



        #region All paints

        [Route("AllPaint")]
        public IActionResult AllPaint()
        {
            AllPaintsVm allPaints = _admin.AllPaints();
            return View(allPaints);
        }

        #endregion

        #region Edit and Delete

        [Route("EditPaint")]
        public IActionResult EditPaint( int id)
        {
            return View();
        }

        [Route("DeletePaint")]
        public IActionResult DeletePaint( int id)
        {
            return View();
        }

        #endregion

    }
}
