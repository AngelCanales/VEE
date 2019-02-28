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
using System.Globalization;

namespace VEE.Controllers
{
    public class AlumnoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alumnoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Alumnoes.Include(a => a.Grado).ToListAsync());
        }


        // GET: Alumnoes/Create
        public async Task<ActionResult> Create()
        {
            var model = new AlumnoViewModels();
            model.Escuela = db.Escuelas.ToList();
            model.Grado = db.Gradoes.ToList();
            return View(model);
        }

        // POST: Alumnoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "IdAlumno,IdEscuela,IdGrado,Codigo,Nombre,Apellido")] AlumnoViewModels alumno
            , HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var escuela = db.Escuelas.Find(alumno.IdEscuela);
                var grado = db.Gradoes.Find(alumno.IdGrado);
                var model = new Alumno()
                {
                    IdAlumno = alumno.IdAlumno,
                    Codigo = alumno.Codigo,
                    Apellido = alumno.Apellido,
                    Escuela = escuela,
                    Grado = grado,
                    Nombre = alumno.Nombre,
                    Foto = Image.ToByteArray()
                };
                db.Alumnoes.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            alumno.Escuela = db.Escuelas.ToList();
            alumno.Grado = db.Gradoes.ToList();
            return View(alumno);
        }

        // GET: Alumnoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var alumno = await db.Alumnoes.Include(a => a.Escuela).Include(a => a.Grado).FirstAsync(d => d.IdAlumno == id.Value);
            var model = new AlumnoViewModels
            {
                Apellido = alumno.Apellido,
                Nombre = alumno.Nombre,
                IdAlumno = alumno.IdAlumno,
                Codigo = alumno.Codigo,
                IdEscuela = alumno.Escuela.Id,
                IdGrado = alumno.Grado.Id,
                Image = alumno.Foto,
                Escuela = db.Escuelas.ToList(),
                Grado = db.Gradoes.ToList()
            };

            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Alumnoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdAlumno,IdEscuela,IdGrado,Codigo,Nombre,Apellido")] AlumnoViewModels alumno
            , HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var escuela = db.Escuelas.Find(alumno.IdEscuela);
                var grado = db.Gradoes.Find(alumno.IdGrado);
                var alum = new Alumno
                {
                    IdAlumno = alumno.IdAlumno,
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Codigo = alumno.Codigo,
                    Grado = grado,
                    Escuela = escuela
                };

            
                if (Image != null && Image.ContentLength > 1)
                {
                        alum.Foto = Image.ToByteArray();
                }

                db.Entry(alum).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            alumno.Escuela = db.Escuelas.ToList();
            alumno.Grado = db.Gradoes.ToList();
            return View(alumno);
        }

        // GET: Alumnoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var alumno = await db.Alumnoes.Include(a => a.Escuela).Include(a => a.Grado).FirstAsync(d => d.IdAlumno == id.Value);
        
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            db.Alumnoes.Remove(alumno);
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
