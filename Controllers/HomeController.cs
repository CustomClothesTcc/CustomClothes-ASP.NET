using CustomClothing.Libraries.Login;
using CustomClothing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomClothing.Controllers
{
    public class HomeController : Controller
    {
       
        private LoginCliente _loginCliente;
        public HomeController(LoginCliente loginCliente)
        {            
            _loginCliente = loginCliente;
        }

        public IActionResult Index()
        {
            ViewBag.LoginCliente = _loginCliente.GetCliente().CPF;
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
