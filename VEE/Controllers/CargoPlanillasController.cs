using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VEE.Models;
using VEE.Models.BasedeDatos;

namespace VEE.Controllers
{
    public class CargoPlanillasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CargoPlanillas
        public async Task<ActionResult> Index()
        {
            return View(await db.CargoPlanillas.ToListAsync());
        }

        // GET: CargoPlanillas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoPlanilla cargoPlanilla = await db.CargoPlanillas.FindAsync(id);
            if (cargoPlanilla == null)
            {
                return HttpNotFound();
            }
            return View(cargoPlanilla);
        }

        // GET: CargoPlanillas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargoPlanillas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Puesto")] CargoPlanilla cargoPlanilla)
        {
            if (ModelState.IsValid)
            {
                db.CargoPlanillas.Add(cargoPlanilla);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cargoPlanilla);
        }

        // GET: CargoPlanillas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoPlanilla cargoPlanilla = await db.CargoPlanillas.FindAsync(id);
            if (cargoPlanilla == null)
            {
                return HttpNotFound();
            }
            return View(cargoPlanilla);
        }

        // POST: CargoPlanillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Puesto")] CargoPlanilla cargoPlanilla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargoPlanilla).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cargoPlanilla);
        }

        // GET: CargoPlanillas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoPlanilla cargoPlanilla = await db.CargoPlanillas.FindAsync(id);
            if (cargoPlanilla == null)
            {
                return HttpNotFound();
            }
            return View(cargoPlanilla);
        }

        // POST: CargoPlanillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CargoPlanilla cargoPlanilla = await db.CargoPlanillas.FindAsync(id);
            db.CargoPlanillas.Remove(cargoPlanilla);
            await db.SaveChangesAsync();
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
