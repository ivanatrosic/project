﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Vehicle.Repository
{
    public class Repository : IRepository
    {
        protected DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }



        public async Task<int> DeleteAsync<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }

        public Task<T> GetOneAsync<T>(string ID) where T : class
        {
            return Context.Set<T>().FindAsync(ID);
        }

        public async Task<int> InsertAsync<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Added;
            return await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<T>(T item) where T : class
        {
            Context.Entry(item).State = EntityState.Modified;
            return await Context.SaveChangesAsync();

        }
        //public T GetById<T> (int id) where T : class
        //{
        //    return Context.Set<T>().Find(id);
        //}

        //public IEnumerable<T> GetAll<T>() where T : class
        //{
        //    return Context.Set<T>().ToList();
        //}

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual IQueryable<T> WhereAsync<T>() where T : class
        {
            return Context.Set<T>().AsNoTracking();
        }
    }
}