namespace CustomClothing.Models
{
    public class Personalizar
    {
        //Criando encapsulamento do objeto com get e set
        public int CodProduto { get; set; }
        public string? Tecido { get; set; }
        public string? Descricao { get; set; }
        public string? DescricaoImg { get; set; }
        public string? Estampa { get; set; }
        public string? Cor { get; set; }
        public int Quantidade { get; set; }
        public string? Tamanho { get; set; }
        public decimal Valor { get; set; }
    }
}
