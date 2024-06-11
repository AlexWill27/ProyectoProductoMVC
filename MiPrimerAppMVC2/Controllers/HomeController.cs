using Microsoft.AspNetCore.Mvc;
using MiPrimerAppMVC2.Models;
using System.Diagnostics;

namespace MiPrimerAppMVC2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.Mensaje = "Este es un mensaje desde el controlador con ViewBag";
            ViewData["Mensaje2"] = "Este es un mensaje desde el controlador con ViewData";
            ViewBag.Contador = 10;
            ViewData["Contador2"] = 20;
            ViewBag.Precio = 123.45m;
            ViewData["Precio2"] = 201.45m;
            ViewBag.Fecha=DateTime.Now;
            ViewData["Fecha2"]=DateTime.Now.AddDays(1);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult VistaDemo()
        {
            //ViewBag.Title = "Vista Demo";
            return View();
        }
        


    }
}
