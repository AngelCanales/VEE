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
using VEE.Util;
namespace VEE.Controllers
{
    public class PlanillasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Planillas
        public async Task<ActionResult> Index()
        {
            return View(await db.Planillas.ToListAsync());
        }

        // GET: Planillas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planilla planilla = await db.Planillas.FindAsync(id);
            if (planilla == null)
            {
                return HttpNotFound();
            }
            return View(planilla);
        }

        // GET: Planillas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planillas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
   



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
         [Bind(Include = "Id,Nombre,Fecha")] Planilla planilla
         , HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid)
            {
                
                var model = new Planilla()
                {
                   Id=planilla.Id,
                   Fecha = planilla.Fecha,
                   Nombre = planilla.Nombre,
                    Foto = Foto.ToByteArray()
                };

                db.Planillas.Add(model);
                var m = new Resultado
                {
                     Id = model.Id,
                     Fecha = DateTime.Now,
                     Planilla=model,
                     Votos = 0
                };

                db.Resultadoes.Add(m);
                
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           
            return View(planilla);
        }
        // GET: Planillas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planilla planilla = await db.Planillas.FindAsync(id);
            if (planilla == null)
            {
                return HttpNotFound();
            }
            return View(planilla);
        }

        // POST: Planillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Fecha,Foto")] Planilla planilla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planilla).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(planilla);
        }

        // GET: Planillas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planilla planilla = await db.Planillas.FindAsync(id);
            if (planilla == null)
            {
                return HttpNotFound();
            }
            return View(planilla);
        }

        // POST: Planillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Planilla planilla = await db.Planillas.FindAsync(id);
            db.Planillas.Remove(planilla);
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
