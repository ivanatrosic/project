
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vehicle.Service;
using Vehicle.MVC.Models;
using AutoMapper;
using System.Linq.Expressions;
using Vehicle.Models;
using Vehicle.Paging;
using System.Net.Http;
using System.Net;

namespace Vehicle.MVC.Controllers
{
    
    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService VMService { get; set; }
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            VMService = vehicleMakeService;
        }



        [Route("api/VehicleMake")]
        [HttpGet]
        public async Task<IHttpActionResult> GetVehicleMake(string Filter, int pageNumber, int pageSize)
        {
            PagingDetails pagingDetails = new PagingDetails(Filter, pageNumber, pageSize);
            var x = Mapper.Map<List<VehicleMakeData>>(await VMService.GetAsync(pagingDetails));
            if (x==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(x);
            }
           
           
        }

        [HttpGet]
        [Route("api/VehicleMake/{id}")]
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            var x = Mapper.Map <VehicleMakeData>( await VMService.GetAsync(id));
            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }
        [HttpPut]
        [Route("api/VehicleMake/{id}")]
        public async Task<HttpResponseMessage> PutVehicleMake(int id, VehicleMakeData vehicleMake)
        {

            if (id != vehicleMake.Id)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            var x = await VMService.UpdateAsync(Mapper.Map<VehicleMakeDTO>(vehicleMake));
            if (x == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleMake);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }
        [HttpPost]
        [Route("api/VehicleMake")]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMakeData vehicleMake)
        {

            var x = await VMService.InsertAsync(Mapper.Map<VehicleMakeDTO>(vehicleMake));

            if (x == 1)
                return Ok(x);
            else
                return InternalServerError();

        }

        [HttpDelete]
        [Route("api/VehicleMake/{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleMake(int id)
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