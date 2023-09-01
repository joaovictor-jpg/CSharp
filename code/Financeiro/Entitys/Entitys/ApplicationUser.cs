using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Entitys
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USER_CPF")]
        public string CPF { get; set; }
    }
}
