﻿using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IExpense
{
    public interface InterfaceExpense : InterfaceGeneric<Expense>
    {
        Task<IList<Expense>> ListarDespesasUsuario(string emailUsuario);
        Task<IList<Expense>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
