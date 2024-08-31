using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class PersonalizarController : Controller
    {
        public IActionResult Personalizar()
        {
            return View();
        }
    }
}
