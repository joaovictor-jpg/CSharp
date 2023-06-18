using Entities.Entities;

namespace Domain.Interfaces.InterfaceService
{
    public interface IFinancialSystemService
    {
        Task AdicionarFinancialSystem(FinancialSystem financialSystem);
        Task AtualizarFinancialSystem(FinancialSystem financialSystem);
    }
}
