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
using Vehicle.Common;
using Vehicle.Service;

namespace Vehicle.MVC.Controllers
{

    [RoutePrefix("api/VehicleModel")]
    public class VehicleModelController : ApiController
    {
        private IVehicleModelService VMService { get; set; }
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            VMService = vehicleModelService;
        }



        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetVehicleModel(string Filter, int pageNumber, int pageSize)
        {
            try
            {
                Paging paging = new Paging(pageNumber, pageSize);
                Filter filter = new Filter(Filter);
                var x = Mapper.Map<IEnumerable<VehicleModelData>>(await VMService.GetAsync(paging, filter));
                if (x == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, x);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }

        }
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("")]
        public async Task<HttpResponseMessage> GetByMake(Guid makeId, int pageNumber, int pageSize)
        {
            try
            { 
            Paging paging = new Paging( pageNumber, pageSize);
            var x = Mapper.Map<IEnumerable<VehicleModelData>>(await VMService.GetByMakeAsync(makeId, paging));

            if (x == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, x);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> GetVehicleModel(Guid id)
        {
            try
            { 
            var x = Mapper.Map<VehicleModelData>(await VMService.GetAsync(id));
            if (x == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, x);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<HttpResponseMessage> PutVehicleModel(VehicleModelData vehicleModel)
        {
            try
            { 
            var x = await VMService.UpdateAsync(Mapper.Map<VehicleModelDTO>(vehicleModel));
            
                return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }

        }
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> PostVehicleModel(VehicleModelData vehicleModel)
        {
            try
            {
                vehicleModel.Id = Guid.NewGuid();
                var x = await VMService.InsertAsync(Mapper.Map<IVehicleModel>(vehicleModel));
                    return Request.CreateResponse(HttpStatusCode.OK, x);

                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }


        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleModel(Guid id)
        {
            try
            { 
            var x = await VMService.DeleteAsync(id);
            if (x != 1)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, x);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }
    }
}
