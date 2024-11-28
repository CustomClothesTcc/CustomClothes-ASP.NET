using CustomClothing.GerenciarArquivo;
using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomClothing.Controllers
{
    public class ProdutoController : Controller
    {
        private IPersonalizarRepositorio _produtoRepositorio;
        private IProdutoRepositorio _produtosRepositorio;

        public ProdutoController(IPersonalizarRepositorio produtoRepositorio, IProdutoRepositorio produtosRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _produtosRepositorio = produtosRepositorio;
        }

        public IActionResult Personalizar()
        {
            var listProdutos = _produtoRepositorio.ObterTodosProdutos();
            return View();
        }

        [HttpPost]
        public ActionResult Personalizar(Personalizar produto, IFormFile file)
        {
            // Obter lista de produtos
            var ListProdutos = _produtoRepositorio.ObterTodosProdutos();

            // Verificar se o arquivo foi enviado
            if (file != null && file.Length > 0)
            {
                // Cadastrar a imagem e obter o caminho
                var Caminho = GerenciadorArquivos.CadastrarImagemProduto(file);
                produto.Estampa = Caminho;  // Salvar o caminho da imagem no produto
            }
            else
            {
                ViewBag.msg = "Nenhuma imagem foi selecionada.";
                return View();
            }

            // Salvar o produto no banco de dados
            _produtoRepositorio.Cadastrar(produto);

            ViewBag.msgPersonzalizar = "Produto personalizado com sucesso!";
            return View();
        }

        public IActionResult CadProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadProduto(Produto produtos, IFormFile file)
        {
            //var ListProdutos = _produtosRepositorio.ObterTodosProdutos();

            // Verificar se o arquivo foi enviado
            if (file != null && file.Length > 0)
            {
                // Cadastrar a imagem e obter o caminho
                var Caminho = GerenciadorArquivos.CadastrarImagemProduto(file);
                produtos.Estampa = Caminho;  // Salvar o caminho da imagem no produto
            }
            else
            {
                ViewBag.msg = "Nenhuma imagem foi selecionada.";
                return View();
            }

            // Salvar o produto no banco de dados
            _produtosRepositorio.Cadastrar(produtos);

            ViewBag.msg = "Produto cadastrado com sucesso!";
            return RedirectToAction("CadProduto");
            
        }

        public IActionResult Produto()
        {
            return View(_produtosRepositorio.ObterTodosProdutos());
        }

        public IActionResult AdicionarCarrinho()
        {
            return View();
        }


    }
}
