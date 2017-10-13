
using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/VehicleMake")]
    public class VehicleMakeController : ApiController
    {
        #region Properites
        private IVehicleMakeService VMService { get; set; }
        #endregion Properites


        #region Constructors
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            VMService = vehicleMakeService;
        }
        #endregion Constructors




        #region Methods
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetVehicleMake(string Filter, int pageNumber, int pageSize)
        {
            try
            {
                PagingDetails pagingDetails = new PagingDetails(Filter, pageNumber, pageSize);
            var x = Mapper.Map<IEnumerable<VehicleMakeData>>(await VMService.GetAsync(pagingDetails));
            if (x==null)
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
        [Route("")]
        public async Task<HttpResponseMessage> GetVehicleMake()
        {
            try
            { 
            var x = Mapper.Map<IEnumerable<VehicleMakeData>>(await VMService.GetAsync());
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
        public async Task<HttpResponseMessage> GetVehicleMake(Guid id)
        {
            try
            { 
            var x = Mapper.Map <VehicleMakeData>( await VMService.GetAsync(id));
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
        public async Task<HttpResponseMessage> PutVehicleMake( VehicleMakeData vehicleMake)
        {
            try
            { 

            var x = await VMService.UpdateAsync(Mapper.Map<VehicleMakeDTO>(vehicleMake));
                return Request.CreateResponse(HttpStatusCode.OK, vehicleMake);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }

        }
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> PostVehicleMake(VehicleMakeData vehicleMake)
        {
            try
            {
                vehicleMake.Id = Guid.NewGuid();
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, vehicleMake);
                }
                else
                {
                    var x = await VMService.InsertAsync(Mapper.Map<VehicleMakeDTO>(vehicleMake));
                    return Request.CreateResponse(HttpStatusCode.OK, x);

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> DeleteVehicleMake(Guid id)
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
        #endregion Methods
    }
}