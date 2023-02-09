using Core.Servises.AdminSer;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HaniehV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
            EditPaintVm paintVm = _admin.GetPaintEdit(id);
            if(paintVm != null)
            {
                return View(paintVm);
            }

            return NotFound();
        }

        [Route("EditPaint")]
        [HttpPost]
        public IActionResult EditPaint(EditPaintVm editPaint)
        {
            _admin.EditPaint(editPaint);
            return RedirectToAction("Main");
        }


        [Route("DeletePaint")]
        public IActionResult DeletePaint( int id)
        {
            DeletePaintVm deletePaint = _admin.GetPaintDelete(id);
            if(deletePaint != null)
            {
                return View(deletePaint);

            }

            return NotFound();
        }

        [Route("DeletePaint")]
        [HttpPost]
        public IActionResult DeletePaint(DeletePaintVm deletePaint)
        {
            _admin.DeletePaint(deletePaint.PainyId);
            bool result  = _admin.IsDeletePaint(deletePaint.PainyId);

            if(result != true)
            {
                ViewBag.IsDeletePaint = false;
                return View(deletePaint);
            }
            return RedirectToAction("Main");

            // delete ==> redirect 
            // problem ==> show error 
        }


        #endregion

        #region Create_Admin

        [Route("CreateAdmin")]
        public IActionResult CreateAdmin() => View();

        [Route("CreateAdmin")]
        [HttpPost]
        public IActionResult CreateAdmin(CreateAdminVm createAdmin )
        {
            if (!_admin.CheckCreateAdmin(createAdmin))
            {
                ViewBag.IsAdminValid = false;
                return View();
            }

            _admin.CreateAdmin(createAdmin);
            ViewBag.IsAdminValid = true;
            return View();
        }
        #endregion

    }
}
