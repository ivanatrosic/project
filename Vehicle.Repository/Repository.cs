using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Vehicle.Repository
{
    public class Repository<TContext> : IRepository<TContext>
        where TContext : class
    {
        protected DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }



        public void Delete<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Deleted;
        }


        public void Insert<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Added;

        }

        public void Update<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Modified;


        }
        //public T GetById<T> (int id) where T : class
        //{
        //    return Context.Set<T>().Find(id);
        //}

        //public IEnumerable<T> GetAll<T>() where T : class
        //{
        //    return Context.Set<T>().ToList();
        //}

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Context.Set<T>().Where(predicate).ToList();
        }
    }
}
