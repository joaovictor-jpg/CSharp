using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Entitys
{
    [Table("UsuarioSistemaFinanceiro")]
    public class UsuarioSistemaFinanceiro
    {
        public int id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }

        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}
