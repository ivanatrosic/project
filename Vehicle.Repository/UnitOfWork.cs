using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using System.Transactions;


namespace Vehicle.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext Context;
        public UnitOfWork(DbContext context)
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
