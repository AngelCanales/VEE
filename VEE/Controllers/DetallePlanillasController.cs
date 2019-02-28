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
    public class DetallePlanillasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetallePlanillas
        public async Task<ActionResult> Index()
        {
            return View(await db.DetallePlanillas.ToListAsync());
        }

        // GET: DetallePlanillas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePlanilla detallePlanilla = await db.DetallePlanillas.FindAsync(id);
            if (detallePlanilla == null)
            {
                return HttpNotFound();
            }
            return View(detallePlanilla);
        }

        // GET: DetallePlanillas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetallePlanillas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] DetallePlanilla detallePlanilla)
        {
            if (ModelState.IsValid)
            {
                db.DetallePlanillas.Add(detallePlanilla);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(detallePlanilla);
        }

        // GET: DetallePlanillas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePlanilla detallePlanilla = await db.DetallePlanillas.FindAsync(id);
            if (detallePlanilla == null)
            {
                return HttpNotFound();
            }
            return View(detallePlanilla);
        }

        // POST: DetallePlanillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] DetallePlanilla detallePlanilla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePlanilla).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detallePlanilla);
        }

        // GET: DetallePlanillas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePlanilla detallePlanilla = await db.DetallePlanillas.FindAsync(id);
            if (detallePlanilla == null)
            {
                return HttpNotFound();
            }
            return View(detallePlanilla);
        }

        // POST: DetallePlanillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DetallePlanilla detallePlanilla = await db.DetallePlanillas.FindAsync(id);
            db.DetallePlanillas.Remove(detallePlanilla);
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
