﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Paging;

namespace Vehicle.Service
{
    public interface IVehicleModelService
    {
        Task<int> InsertAsync(IVehicleModel item);
        Task<int> UpdateAsync(IVehicleModel item);
        Task<int> DeleteAsync(IVehicleModel item);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<IVehicleModel>> GetAllAsync(PagingDetails pagingDetails);
        Task<IEnumerable<IVehicleModel>> FilterByMakeAsync(int makeId, PagingDetails pagingDetails);
        Task<IVehicleModel> GetAsync(int ID);


    }
}
