using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;

namespace Domain.Services
{
    public class FinancialSystemServices : IFinancialSystemService
    {

        private readonly InterfaceFinancialSistem _interfaceFinancialSistem;

        public FinancialSystemServices(InterfaceFinancialSistem interfaceFinancialSistem)
        {
            _interfaceFinancialSistem = interfaceFinancialSistem;
        }

        public async Task AdicionarFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.PropertyIsValidString(financialSystem.Name, "Name");

            if(valid)
            {
                var date = DateTime.Now;

                financialSystem.Dayclosure = 1;
                financialSystem.Year = date.Year;
                financialSystem.Month = date.Month;
                financialSystem.CopyYear = date.Year;
                financialSystem.CopyMonth = date.Month;
                financialSystem.GenerateExpenseCopy = true;

                await _interfaceFinancialSistem.Add(financialSystem);
            }
        }

        public async Task AtualizarFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.PropertyIsValidString(financialSystem.Name, "Name");

            if (valid)
            {
                var date = DateTime.Now;

                financialSystem.Dayclosure = 1;

                await _interfaceFinancialSistem.Add(financialSystem);
            }
        }
    }
}
