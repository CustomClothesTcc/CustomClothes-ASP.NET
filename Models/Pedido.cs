namespace CustomClothing.Models
{
    public class Pedido
    {
        //Criando encapsulamento do objeto com get e set
        public string IdPedido { get; set; }
        public string DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string PedidoStatus { get; set; }
        public int Quantidade { get; set; }
        public string CPFCli { get; set; }

    }
}
