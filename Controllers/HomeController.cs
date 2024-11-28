using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomClothing.Controllers
{
    public class HomeController : Controller
    {

        private IProdutoRepositorio _produtoRepositorio;
        public HomeController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_produtoRepositorio.ObterTodosProdutos());
        }
      
        public IActionResult Sobrenos()
        {
            return View();
        }

        public IActionResult Finalizada()
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
