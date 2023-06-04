using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitites.Entities
{
    [Table("TB_MESSAGE")]
    internal class Message : Notifies
    {
        [Column("MSN_ID")]
        public int Id { get; set; }
        [Column("MSN_TITULO")]
        [MaxLength(255)]
        public string titulo { get; set; }
        [Column("MSN_ATIVO")]
        public bool Ativo { get; set; }
        [Column("MSN_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("MSN_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
