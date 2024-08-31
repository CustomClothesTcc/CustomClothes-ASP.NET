using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Produto()
        {
            return View();
        }
    }
}
