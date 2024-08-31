using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
