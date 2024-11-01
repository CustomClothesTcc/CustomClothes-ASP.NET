using CustomClothing.Libraries.Login;
using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class LoginController : Controller
    {
        //Injeção de dependência
        private IClienteRepositorio _clienteRepositorio;
        private Login _login;
        public LoginController(IClienteRepositorio clienteRepositorio, Login login)
        {
            _clienteRepositorio = clienteRepositorio;
            _login = login; 
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {
            Cliente clienteDB = _clienteRepositorio.Login(cliente.Email, cliente.Senha);
            if (clienteDB.Email != null && clienteDB.Senha != null)
            {
               _login.LoginCliente(clienteDB);
                return new RedirectResult(Url.Action(nameof(PerfilCliente)));
            }
            else
            {
                //Erro na sessão
                ViewData["MSG_E"] = "Usuario não localizado, por favor verifique e-mail e senha digitado";
                return View();
            }
        }
        public IActionResult PerfilCliente()
        {
            ViewBag.Nome = _login.GetCliente().Nome;
            ViewBag.Celular = _login.GetCliente().Celular;
            ViewBag.Email = _login.GetCliente().Email;
            return View();
        }
        public IActionResult LogoutCliente()
        {
            _login.Logout();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
