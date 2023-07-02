using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("UserFinancialSystem")]
    public class UserFinancialSystem
    {
        public int Id { get; set; }
        public string EmailUser { get; set; }
        public bool Administrator { get; set; }
        public bool SystemCurrent { get; set; }

        [ForeignKey("FinancialSystem")]
        [Column(Order = 1)]
        public int IdSystem { get; set; }
        // public virtual FinancialSystem FinancialSystem { get; set;}
    }
}
