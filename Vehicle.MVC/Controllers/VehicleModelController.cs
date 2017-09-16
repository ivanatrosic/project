using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vehicle.Models;
using Vehicle.MVC.Models;
using Vehicle.Paging;
using Vehicle.Service;

namespace Vehicle.MVC.Controllers
{
    public class VehicleModelController : ApiController
    {
        private IVehicleModelService VMService { get; set; }
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            VMService = vehicleModelService;
        }



        [Route("api/VehicleModel")]
        [HttpGet]
        public async Task<IHttpActionResult> GetVehicleModel(int pageNumber, int pageSize)
        {
            PagingDetails pagingDetails = new PagingDetails(pageNumber, pageSize);
            var x = await VMService.GetAllAsync(pagingDetails);
            if (x == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(x);
            }


        }
        [HttpGet]
        [Route("api/VehicleModel/{MadeId}")]
        public async Task<IHttpActionResult> GetFilterByMake(int madeId, int pageNumber, int pageSize)
        {
            PagingDetails pagingDetails = new PagingDetails(pageNumber, pageSize);
            var x = await VMService.FilterByMakeAsync(madeId, pagingDetails);

            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }

        [HttpGet]
        [Route("api/VehicleModel/{id}")]
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            var x = await VMService.GetAsync(id);
            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }
        [HttpPut]
        [Route("api/VehicleModel/{id}")]
        public async Task<HttpResponseMessage> PutVehicleModel(int id, VehicleModelData vehicleModel)
        {

            if (id != vehicleModel.Id)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            var x = await VMService.UpdateAsync(Mapper.Map<VehicleModelDTO>(vehicleModel));
            if (x == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }
        [HttpPost]
        [Route("api/VehicleModel")]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleModelData vehicleModel)
        {

            var x = await VMService.InsertAsync(Mapper.Map<VehicleModelDTO>(vehicleModel));

            if (x == 1)
                return Ok(x);
            else
                return InternalServerError();

        }

        [HttpDelete]
        [Route("api/VehicleModel/{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleModel(int id)
        {
            var x = await VMService.DeleteAsync(id);
            if (x != 1)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            await VMService.DeleteAsync(x);
            return Request.CreateResponse(HttpStatusCode.OK, x);
        }
    }
}
