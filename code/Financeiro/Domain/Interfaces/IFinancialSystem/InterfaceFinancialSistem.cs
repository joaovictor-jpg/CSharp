using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IFinancialSystem
{
    public interface InterfaceFinancialSistem : InterfaceGeneric<FinancialSystem>
    {
        Task<IList<FinancialSystem>> ListaSistemasUsuario(string emailUsuario);
    }
}
