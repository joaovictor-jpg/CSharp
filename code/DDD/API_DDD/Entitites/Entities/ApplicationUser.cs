using Entitites.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitites.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USER_CPF")]
        public string CPF { get; set; }
        [Column("USER_TIPO")]
        public TipoUsuario? Tipo { get; set; }
    }
}
