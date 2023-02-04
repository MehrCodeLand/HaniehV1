using Core.Servises.MainSer;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
