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
        Task<int> DeleteAsync<T>(Guid? id) where T : class;
        Task<T> GetOneAsync<T>(Guid? ID) where T : class;
        IQueryable<T> WhereAsync<T>() where T : class;

    }
}
