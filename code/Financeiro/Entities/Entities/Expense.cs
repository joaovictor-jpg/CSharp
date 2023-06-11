using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("Expense")]
    public class Expense : Base
    {
        public decimal Valor { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public EnumTypeExpense EnumTypeExpense { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime PaymentDate { get; set;}
        public DateTime MaturityDate { get; set; }
        public bool PaidOut { get; set; }
        public bool LateExpense { get; set;}

        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int IdCategory { get; set; }
        public virtual Category Category { get; set; }
    }
}
