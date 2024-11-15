using System.ComponentModel.DataAnnotations;

namespace CustomClothing.Models
{
    public class Funcionario
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPFunc { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O RG é obrigatório")]
        public string RG { get; set; }

        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O Nome Completo é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "A data é obrigatoria")]
        public DateOnly DataNans { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O Celular é obrigatorio")]
        public string Celular { get; set; }


        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O Cargo é obrigatorio")]
        public string Cargo { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O Sexo é obrigatorio")]
        [StringLength(1, ErrorMessage = "Deve conter 1 caracter")]
        public string Sexo { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O senha é obrigatorio")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Senha { get; set; }
    }
}
