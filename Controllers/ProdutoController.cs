using CustomClothing.GerenciarArquivo;
using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomClothing.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Personalizar()
        {
            var listProdutos = _produtoRepositorio.ObterTodosProdutos();
            ViewBag.Produtos = new SelectList(listProdutos, "Descricao", "Estampa", "Tamanho", "Valor");
            return View();
        }

        [HttpPost]
        public IActionResult Personalizar(Produto produto, IFormFile file)
        {
           
            var listProdutos = _produtoRepositorio.ObterTodosProdutos();
            ViewBag.Produtos = new SelectList(listProdutos, "Descricao", "Estampa", "Tamanho", "Valor");
            var Caminho = GerenciadorArquivos.CadastrarImagemProduto(file);
            produto.Estampa = Caminho;
            _produtoRepositorio.Cadastrar(produto);
            ViewBag.msg = "Estampa Adicionado com Sucesso!";
            return View();
        }

        public IActionResult Produto()
        {
            return View();
        }


    }
}
