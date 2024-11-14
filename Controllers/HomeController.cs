using CustomClothing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomClothing.Controllers
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
            return View();
        }
      
        public IActionResult Sobrenos()
        {
            return View();
        }

        public IActionResult Finalizada()
        {
            return View();
        }

        public IActionResult PerfilCliente()
        {
            return View();
        }
        public IActionResult Confirmar()
        {
            return View();
        }

        public IActionResult Problema()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
