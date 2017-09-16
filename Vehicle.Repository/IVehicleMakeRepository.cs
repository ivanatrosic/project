using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Repository;
using Vehicle.Paging;

namespace Vehicle.Repository
{
    public interface IVehicleMakeRepository
    {

        Task<IEnumerable<IVehicleMake>> GetAllAsync(PagingDetails pagingDetails);
        Task<IEnumerable<IVehicleMake>> FilterAsync(string filter, PagingDetails pagingDetails);
        //Task<IEnumerable<IVehicleMake>> SortAsync();
        Task<int> InsertAsync(IVehicleMake item);
        Task<int> UpdateAsync(IVehicleMake item);
        Task<IVehicleMake> GetAsync(int id);
        Task<int> DeleteAsync(IVehicleMake item);
        Task<int> DeleteAsync(int id);





    }
}