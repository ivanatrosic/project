﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Paging;

namespace Vehicle.Repository
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetAllAsync(PagingDetails pagingDetails);
        Task<IEnumerable<IVehicleModel>> FilterByMakeAsync(int filter, PagingDetails pagingDetails);
        Task<int> InsertAsync(IVehicleModel item);
        Task<int> UpdateAsync(IVehicleModel item);
        Task<IVehicleModel> GetAsync(int id);
        Task<int> DeleteAsync(IVehicleModel item);
        Task<int> DeleteAsync(int id);
    }
}