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
    public class SalidasController : Controller
    {
        private ServicesDB db = new ServicesDB();

        // GET: Salidas
        public ActionResult Index()
        {
            var salidas = db.Salidas.Include(s => s.Empleados).Include(s => s.TipoSalidas);
            return View(salidas.ToList());
        }

        // GET: Salidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salidas salidas = db.Salidas.Find(id);
            if (salidas == null)
            {
                return HttpNotFound();
            }
            return View(salidas);
        }

        // GET: Salidas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre");
            ViewBag.TipoSalida = new SelectList(db.TipoSalidas, "TipoSalidaId", "TipoSalidas");
            return View();
        }

        // POST: Salidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalidaId,EmpleadoId,TipoSalida,Motivo,FechaSalida")] Salidas salidas)
        {
            if (ModelState.IsValid)
            {
                db.Salidas.Add(salidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", salidas.EmpleadoId);
            ViewBag.TipoSalida = new SelectList(db.TipoSalidas, "TipoSalidaId", "TipoSalidas", salidas.TipoSalida);
            return View(salidas);
        }

        // GET: Salidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salidas salidas = db.Salidas.Find(id);
            if (salidas == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", salidas.EmpleadoId);
            ViewBag.TipoSalida = new SelectList(db.TipoSalidas, "TipoSalidaId", "TipoSalidas", salidas.TipoSalida);
            return View(salidas);
        }

        // POST: Salidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalidaId,EmpleadoId,TipoSalida,Motivo,FechaSalida")] Salidas salidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre", salidas.EmpleadoId);
            ViewBag.TipoSalida = new SelectList(db.TipoSalidas, "TipoSalidaId", "TipoSalidas", salidas.TipoSalida);
            return View(salidas);
        }

        // GET: Salidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salidas salidas = db.Salidas.Find(id);
            if (salidas == null)
            {
                return HttpNotFound();
            }
            return View(salidas);
        }

        // POST: Salidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salidas salidas = db.Salidas.Find(id);
            db.Salidas.Remove(salidas);
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
