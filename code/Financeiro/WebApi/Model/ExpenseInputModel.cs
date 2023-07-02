using Entities.Enums;

namespace WebApi.Model
{
    public class ExpenseInputModel
    {
        public string Name { get; set; }
        public decimal Valor { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public EnumTypeExpense EnumTypeExpense { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public bool PaidOut { get; set; }
        public bool LateExpense { get; set; }

        public int IdCategory { get; set; }
    }
}
