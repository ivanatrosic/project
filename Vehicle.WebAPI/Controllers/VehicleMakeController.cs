using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vehicle.DAL;
using Vehicle.Service;

namespace Vehicle.WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    { 
    public IVehicleMakeService VMService { get; set; }
    public VehicleMakeController(IVehicleMakeService vehicleMakeService)
    {
        VMService = vehicleMakeService;
    }

        [HttpGet]
        // GET: api/VehicleMake
        public async Task<IHttpActionResult> GetVehicleMake()
        {
            var x = await VMService.GetAllAsync();
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
    // GET: api/VehicleMake
    public async Task<IHttpActionResult> GetFilterVehicleMake(string filter)
    {
        IEnumerable<VehicleMake> x = await VMService.FilterAsync(filter);

        if (x == null)
        {
            return NotFound();
        }

        return Ok(x);
    }
    [HttpGet]
    // GET: api/VehicleMake/5
    [ResponseType(typeof(VehicleMake))]
    public async Task<IHttpActionResult> GetVehicleMake(int id)
    {
        VehicleMake x = await VMService.GetOneAsync(id);
        if (x == null)
        {
            return NotFound();
        }

        return Ok(x);
    }
    [HttpPut]
    // PUT: api/VehicleMake/5
    [ResponseType(typeof(void))]
    public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMake vehicleMake)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != vehicleMake.Id)
        {
            return NotFound();
        }

        var x = await VMService.UpdateAsync(vehicleMake);
        if (x == 1)
        {
            return Ok(vehicleMake);

        }
        else
        {
            return StatusCode(HttpStatusCode.InternalServerError);
        }

    }
    [HttpPost]
    // POST: api/VehicleMake
    [ResponseType(typeof(VehicleMake))]
    public async Task<IHttpActionResult> PostVehicleMake(VehicleMake vehicleMake)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var x = await VMService.InsertAsync(vehicleMake);

        if (x != 0)
            return Ok(x);

        return CreatedAtRoute("DefaultApi", new { id = vehicleMake.Id }, vehicleMake);
    }

    [HttpDelete]
    // DELETE: api/VehicleMake/5
    [ResponseType(typeof(VehicleMake))]
    public async Task<IHttpActionResult> DeleteVehicleMake(int id)
    {
        VehicleMake vehicleMake = await VMService.GetOneAsync(id);
        if (vehicleMake == null)
        {
            return NotFound();
        }

        await VMService.DeleteAsync(vehicleMake);
        return Ok(vehicleMake);
    }

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        db.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}

    //private bool VehicleMakeExists(int id)
    //{
    //    return db.VehicleMake.Count(e => e.Id == id) > 0;
    //}
}
}
