using CustomClothing.CarrinhoCompra;
using CustomClothing.Models;
using CustomClothing.Repositorio.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CustomClothing.Controllers
{
    public class CompraController : Controller
    {
        private CookiesCarrinhoCompra _cookiesCarrinhoCompra;
        private IProdutoRepositorio _produtoRepositorio;
        private IitemRepositorio _itemRepositorio;
        private IPedidoRepositorio _pedidoRepositorio;
        public CompraController(IProdutoRepositorio produtoRepositorio, CookiesCarrinhoCompra cookiesCarrinhoCompra, IitemRepositorio itemRepositorio, IPedidoRepositorio pedidoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _cookiesCarrinhoCompra = cookiesCarrinhoCompra;
            _itemRepositorio = itemRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }
        public IActionResult AdicionarItem(int id)
        {
            Produto produto = _produtoRepositorio.ObterProdutos(id);

            if (produto == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new Produto()
                {
                    IdProduto = id,
                    Quantidade = 1,
                    Descricao = produto.Descricao,
                    Estampa = produto.Estampa,
                    Tamanho = produto.Tamanho,
                    Valor = produto.Valor
                };
                _cookiesCarrinhoCompra.Cadastrar(item);
                return RedirectToAction(nameof(Carrinho));
            }
        }
        public object Carrinho()
        {
            return View(_cookiesCarrinhoCompra.Consultar());
        }
        public IActionResult LimparCarrinho()
        {
            _cookiesCarrinhoCompra.Removertodos();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoverItem(int id)
        {
            _cookiesCarrinhoCompra.Remover(new Produto() { IdProduto = id });
            return RedirectToAction(nameof(Carrinho));

        }
        public IActionResult Finalizada()
        {
            return View();
        }
        public IActionResult Problema()
        {
            return View();
        }
        public IActionResult SalvarCarrinho()
        {
            return RedirectToAction(nameof(Finalizada)); 
        }
    }
}
