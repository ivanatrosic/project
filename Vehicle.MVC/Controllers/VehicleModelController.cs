using AutoMapper;
using PagedList;
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
        public async Task<IHttpActionResult> GetVehicleModel(string Filter, int pageNumber, int pageSize)
        {
            PagingDetails pagingDetails = new PagingDetails(Filter, pageNumber, pageSize);
            var x = Mapper.Map < IEnumerable < VehicleModelData >>( await VMService.GetAsync(pagingDetails));
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
        [AcceptVerbs("GET")]
        [Route("api/VehicleModel")]
        public async Task<IHttpActionResult> GetByMake(string makeId, int pageNumber, int pageSize)
        {
            PagingDetails pagingDetails = new PagingDetails(null, pageNumber, pageSize);
            var x = Mapper.Map<IEnumerable<VehicleModelData>>(await VMService.GetByMakeAsync(makeId, pagingDetails));

            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }

        [HttpGet]
        [Route("api/VehicleModel/{id}")]
        public async Task<IHttpActionResult> GetVehicleModel(string id)
        {
            var x = Mapper.Map<VehicleModelData>(await VMService.GetAsync(id));
            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }
        [HttpPut]
        [Route("api/VehicleModel/{id}")]
        public async Task<HttpResponseMessage> PutVehicleModel(VehicleModelData vehicleModel)
        {

            var x = await VMService.UpdateAsync(Mapper.Map<VehicleModelDTO>(vehicleModel));
            
                return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);



        }
        [HttpPost]
        [Route("api/VehicleModel")]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleModelData vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(vehicleModel);
            }
            else
            {
                var x = await VMService.InsertAsync(Mapper.Map<IVehicleModel>(vehicleModel));
                return Ok(x);

            }

  

        }

        [HttpDelete]
        [Route("api/VehicleModel/{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleModel(string id)
        {
            var x = await VMService.DeleteAsync(id);
            if (x != 1)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, x);
        }
    }
}
