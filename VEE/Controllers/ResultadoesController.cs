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
    public class ResultadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resultadoes
        public async Task<ActionResult> Index()
        {
            var resu = await db.Resultadoes.Include(c => c.Planilla).OrderByDescending(v => v.Votos).ToListAsync();
            var model = new ResultadoViewModel();

            
            model.Resultados = resu.Select(d => new Resultadomodel
            {
                Id = d.Id,
                Fecha = d.Fecha,
                Planilla = d.Planilla,
                puesto = "",
                Votos = d.Votos
            
            }).OrderByDescending(v => v.Votos);

            var mb = new List<Resultadomodel>();
            int x = 0;
            foreach (var item in model.Resultados)
            {

                item.puesto = cargo(x);
                mb.Add(item);
                x = x + 1;
            }
            model.Resultados = mb.Select(d => new Resultadomodel
            {
                Id = d.Id,
                Fecha = d.Fecha,
                Planilla = d.Planilla,
                puesto = d.puesto,
                Votos = d.Votos

            }).OrderByDescending(v => v.Votos);





            return View(model);
        }

        public string cargo(int x)
        {
            
            if (x == 0) { return "Presidencia"; }
            if (x == 1) { return "Vice Presidencia"; }
            if (x == 2) { return "Secretaria"; }
            if (x == 3) { return "Pro Secretaria"; }
            if (x == 4) { return "Tesoreria"; }
            if (x == 5) { return "Fiscalia"; }
            if (x == 6) { return "Vocalia"; }
            if (x > 6) { return "No obtuvo un puesto"; }
            else { return "No obtuvo un puesto"; }
             

        }
        [HttpPost]
        public async Task<JsonResult> planillajson()
        {
            var resu = await db.Resultadoes.Include(c => c.Planilla).OrderByDescending(v => v.Votos).Take(7).ToListAsync();
            var d = resu.Select(n => new
            {
                Nombre = n.Planilla.Nombre,
                Votos = n.Votos
            }
            );
         
            return Json(d);
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
