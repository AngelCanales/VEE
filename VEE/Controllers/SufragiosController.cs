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
    public class SufragiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sufragios
        public async Task<ActionResult> Index()
        {
            return View(await db.Planillas.OrderBy(c=>c.Nombre).ToListAsync());
        }


        public async Task<ActionResult> votar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postulado = await db.Planillas.FindAsync(id);
            if (postulado == null)
            {
                return HttpNotFound();
            }
            return View(postulado);
        }

        public async Task<ActionResult> Realizarvoto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postulado = await db.Planillas.FindAsync(id);
            
            if (postulado == null)
            {
                return HttpNotFound();
            }

            var planillasum = await db.Resultadoes.Include( c => c.Planilla).FirstOrDefaultAsync( d => d.Planilla.Id== postulado.Id);
            planillasum.Votos = planillasum.Votos + 1;

            db.Entry(planillasum).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return View(postulado);
        }
        
      

        // GET: Sufragios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sufragios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Fecha")] Sufragio sufragio)
        {
            if (ModelState.IsValid)
            {
                db.Sufragios.Add(sufragio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sufragio);
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
