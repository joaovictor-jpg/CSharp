﻿namespace Domain.Interfaces.Generics
{
    public interface InterfaceGeneric<T> where T : class
    {
        Task Add(T Object);
        Task Update (T Object);
        Task Delete(T Object);
        Task<T> GetEntityById(string Id);
        Task<List<T>> List();
    }
}
