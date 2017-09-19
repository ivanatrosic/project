using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Vehicle.DAL;
using System.Threading.Tasks;
using System.Transactions;


namespace Vehicle.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IVehicleContext Context;
        public UnitOfWork(IVehicleContext context)
        {
            Context = context;
        }

        public async Task<int> CommitAsync()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await Context.SaveChangesAsync();
                scope.Complete();
                return 0;
            }
        }

        public Task<int> DeleteAsync<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Deleted;
            return Task.FromResult(1);

        }

        public Task<int> DeleteAsync<T>(string id) where T : class
        {
            var x = Context.Set<T>().Find(id);
            if (x == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(x);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<int> InsertAsync<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Added;
            return Task.FromResult(1);
        }

        public Task<int> UpdateAsync<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Modified;
            return Task.FromResult(1);
        }
    }
}
