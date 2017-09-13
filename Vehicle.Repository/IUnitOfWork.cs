using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Repository;

namespace Vehicle.Repository
{
    public interface IUnitOfWork :IDisposable
    {
        Task<int> CommitAsync();

        Task<int> InsertAsync<T>(T item) where T : class;
        Task<int> UpdateAsync<T>(T item) where T : class;
        Task<int> DeleteAsync<T>(T item) where T : class;
        Task<int> DeleteAsync<T>(int id) where T : class;

    }
}
