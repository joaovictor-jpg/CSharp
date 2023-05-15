using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public String Login { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public String Senha { get; set; }
    }
}
