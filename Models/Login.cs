using System.ComponentModel.DataAnnotations;

namespace CustomClothing.Models
{
    public class Login
    {
        //Criando encapsulamento do objeto com get e set
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Email do Usuário!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a Senha do Usuário!")]
        public string Senha { get; set; }
       

    }
}
