using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.DAL;
using Vehicle.Service;
using System.Net.Http;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private IVehicleMakeRepository vehicleMakeRepository;
        public VehicleMakeController()
        {
            this.vehicleMakeRepository = new VehicleMakeRepository(new VehicleContext());
        }
        // GET: VehicleMake
        public ActionResult Index()
        {
            var vehiclemake = from vehicle in vehicleMakeRepository.GetVehicleMake()
                        select vehicle;
            return View(vehiclemake);
        }
    }
}