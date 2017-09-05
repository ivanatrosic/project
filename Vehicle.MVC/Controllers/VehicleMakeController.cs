using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle.DAL;
using Vehicle.Service;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {

        IVehicleMakeService Service;


        public VehicleMakeController(IVehicleMakeService service)
        {
            Service = service;
        }


        // GET: VehicleMake
        public ActionResult Index(string filter)
        {
 
            if (filter != null)
            {
               return View( Service.FilterAsync(filter));
            }
           else
                return View(Service.GetAllAsync());
        }

        // GET: VehicleMake/Details/5
        public ActionResult Details(int id)
        {

            //VehicleMake vehicleMake = Service.GetByIdAsync(id);
            //if (vehicleMake == null)
            //{
            return HttpNotFound();
            //}
            //return View(vehicleMake);
        }

        // GET: VehicleMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                Service.InsertAsync(vehicleMake);
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMake/Edit/5
        public ActionResult Edit(int id)
        {
            //VehicleMake vehicleMake = Service.GetByIdAsync(id);

            //if (vehicleMake == null)
            //{
               return HttpNotFound();
            //}
            //return View(vehicleMake);
        }

        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                Service.UpdateAsync(vehicleMake);
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(int id)
        {

            //VehicleMake vehicleMake = Service.GetByIdAsync(id);
            //if (vehicleMake == null)
            //{
               return HttpNotFound();
            //}
            //return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //VehicleMake vehicleMake = Service.GetByIdAsync(id);
            //Service.DeleteAsync(vehicleMake);
           return RedirectToAction("Index");
        }

    }
}
