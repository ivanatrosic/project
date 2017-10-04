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
        #region Properties
        private IVehicleContext Context;
        #endregion Properties



        #region Constructors
        public UnitOfWork(IVehicleContext context)
        {
            Context = context;
        }
        #endregion Constructors


        #region Methods
        public virtual Task<int> AddAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Added;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                result = await Context.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public Task<int> DeleteAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Deleted;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Task<int> DeleteAsync<T>(string id) where T : class
        {
            try
            {
                var x = Context.Set<T>().Find(id);
                if (x == null)
                {
                   return Task.FromResult(0);
                }
                 return DeleteAsync<T>(x);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<int> InsertAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Added;
            return Task.FromResult(1);
             }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> UpdateAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Modified;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Methods
    }
}
