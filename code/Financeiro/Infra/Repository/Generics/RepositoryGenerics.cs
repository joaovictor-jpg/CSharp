﻿using Domain.Interfaces.Generics;
using Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace Infra.Repository.Generics
{
    public class RepositoryGenerics<T> : InterfaceGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryGenerics()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Object)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Object);
                int n = await data.SaveChangesAsync();

                Console.WriteLine(n);
            }
        }

        public async Task Delete(T Object)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Remove(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T Object)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
