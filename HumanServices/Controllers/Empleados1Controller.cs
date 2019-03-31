using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanServices.Models;

namespace HumanServices.Controllers
{
    public class Empleados1Controller : Controller
    {
        private ServicesDB db = new ServicesDB();

        // GET: Empleados1
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos);
            return View(empleados.ToList());
        }

        // GET: Empleados1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados1/Create
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Cargo");
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: Empleados1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId,CodigoEmp,Nombre,Apellido,Telefono,DepartamentoId,CargoId,FechaIngreso,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Cargo", empleados.CargoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", empleados.DepartamentoId);
            return View(empleados);
        }

        // GET: Empleados1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Cargo", empleados.CargoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", empleados.DepartamentoId);
            return View(empleados);
        }

        // POST: Empleados1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoId,CodigoEmp,Nombre,Apellido,Telefono,DepartamentoId,CargoId,FechaIngreso,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Cargo", empleados.CargoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", empleados.DepartamentoId);
            return View(empleados);
        }

        // GET: Empleados1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
