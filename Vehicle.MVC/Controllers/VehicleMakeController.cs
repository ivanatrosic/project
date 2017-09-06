using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Service;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService VMService { get; set; }
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            VMService = vehicleMakeService;
        }

        private VehicleContext db = new VehicleContext();

        // GET: api/VehicleMake
        public IQueryable<VehicleMake> GetVehicleMake()
        {
            return db.VehicleMake;
        }

        // GET: api/VehicleMake/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult GetVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMake/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleMake(int id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleMake.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicleMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleMake
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult PostVehicleMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleMake.Add(vehicleMake);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VehicleMakeExists(vehicleMake.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vehicleMake.Id }, vehicleMake);
        }

        // DELETE: api/VehicleMake/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            db.VehicleMake.Remove(vehicleMake);
            db.SaveChanges();

            return Ok(vehicleMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleMakeExists(int id)
        {
            return db.VehicleMake.Count(e => e.Id == id) > 0;
        }
    }
}