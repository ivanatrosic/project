


namespace Vehicle.Service
{ 

using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

    public class Repo <TContext>: IRepo
        where TContext: DbContext, new()
    {
        public Repo()
        {
            Context = new TContext();
        }
        public TContext Context { get; set; }
        public T Delete<T>(T item, bool saveNow) where T : class
        {
            Context.Entry(item).State = EntityState.Deleted;
            if (saveNow)
                Context.SaveChanges();
            return item;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public T Insert<T>(T item, bool saveNow) where T : class
        {
            Context.Entry(item).State = EntityState.Added;
            if (saveNow)
                Context.SaveChanges();
            return item;
        }

        public T Update<T>(T item, bool saveNow) where T : class
        {
            Context.Entry(item).State = EntityState.Modified;
            if (saveNow)
                Context.SaveChanges();
            return item;
        }
    }

}
