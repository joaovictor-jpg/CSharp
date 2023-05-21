using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual do usuáro")]
        public string SenhaAtual { get; set;}
        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        public string NovaSenha { get; set;}
        [Required(ErrorMessage = "Confirma a nova senha do usuário")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmaNovaSenha { get;set;}
    }
}
