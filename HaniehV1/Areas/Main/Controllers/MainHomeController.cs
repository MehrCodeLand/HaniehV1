using Core.Servises.MainSer;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace HaniehV1.Areas.Main.Controllers
{
    [Area("Main")]
    public class MainHomeController : Controller
    {
        private readonly IMainService _main;
        public MainHomeController(IMainService main)
        {
            _main = main;
        }


        public IActionResult Main()
        {
            AllPaintForMainVm allPaint = _main.GetAllPaint();  
            return View(allPaint);
        }



        [Route("ShowPaint")]
        public IActionResult ShowPaint( int id)
        {
            ShowPaintVm showPaint = _main.GetPaintShow(id);
            if(showPaint != null)
            {
                return View(showPaint);
            }
            return RedirectToAction("Main"); 
        }

        #region login_Admin

        [Route("SignIn")]
        public IActionResult SignIn() => View();

        [Route("Signin")]
        [HttpPost]
        public IActionResult Signin(SignInVm signIn)
        {
            // first validation
            if (!_main.IsUsernameValid(signIn))
            {
                ViewBag.IsUsernameValid = false;
                return View();
            }


            // ready for signIn
            Data.Models.Admin admin = _main.GetAdminByUsername(signIn.Username);
            if(admin != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,admin.MyAdminId.ToString()),
                    new Claim(ClaimTypes.Name,admin.Username),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                };

                HttpContext.SignInAsync(principal, properties);
            }

            return View();
        }

        #endregion
    }
}
