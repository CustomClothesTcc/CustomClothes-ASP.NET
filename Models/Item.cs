namespace CustomClothing.Models
{
    public class Item
    {
        //Criando encapsulamento do objeto com get e set
        public int CodItemPedido { get; set; }
        public int CodProduto { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}
