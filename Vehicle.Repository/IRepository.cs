using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Vehicle.Repository
{
    public interface IRepository
    {
        //T GetById<T>(int id) where T : class;
        Task<int> InsertAsync<T>(T item) where T : class;
        Task<int> UpdateAsync<T>(T item) where T : class;
        Task<int> DeleteAsync<T>(T item) where T : class;
        Task<int> DeleteAsync<T>(int id) where T : class;
        Task<T> GetOneAsync<T>(int ID) where T : class;
        IQueryable<T> WhereAsync<T>() where T : class;
        //Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<int> OrderAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        //IEnumerable<T> GetAll<T>() where T : class;
    }
}
