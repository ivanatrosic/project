using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Vehicle.DAL;
using Vehicle.Common;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class Repository : IRepository
    {
        #region Properties
        protected IVehicleContext Context { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        #endregion Properties

        #region Constructors
        public Repository(IVehicleContext context, IUnitOfWorkFactory unitOfWorkFactory)
        {
            Context = context;
            UnitOfWorkFactory = unitOfWorkFactory;
        }
        #endregion Constructors

        #region Methods

        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }

        public async Task<int> DeleteAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Deleted;
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteAsync<T>(Guid? id) where T : class
        {
            var entity = await GetOneAsync<T>(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity with specified id not found.");
            }
            return await DeleteAsync(entity);
        }

        public Task<T> GetOneAsync<T>(Guid? ID) where T : class
        {
            return Context.Set<T>().FindAsync(ID);
        }

        public async Task<int> InsertAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Added;
               return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
}

        public async Task<int> UpdateAsync<T>(T item) where T : class
        {
            try
            {
                Context.Entry(item).State = EntityState.Modified;
                 return await Context.SaveChangesAsync();
              }
            catch (Exception e)
            {
                throw e;
            }
}


        public virtual IQueryable<T> WhereAsync<T>() where T : class
        {
            return Context.Set<T>().AsNoTracking();
        }

        #endregion Methods
    }
}
