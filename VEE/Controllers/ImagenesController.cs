using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VEE.Util;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using VEE.Models;
using VEE.Models.BasedeDatos;

namespace VEE.Controllers
{
    public class ImagenesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task<FileResult> SmallImage(int id)
        {
            var DishImage =await GetAlumnoImageContent(id, ImageFormat.Png, 100, 100);

            return File(DishImage, "image/png");
        }
        public async Task<FileResult> SmallImagePlanilla(int id)
        {
            var DishImage = await GetPlanillaImageContent(id, ImageFormat.Png, 800, 800);

            return File(DishImage, "image/png");
        }

        public async Task<FileResult> LargeImage(int id)
        {
            var DishImage = await GetAlumnoImageContent(id, ImageFormat.Png, 200, 200);

            return File(DishImage, "image/png");
        }

   
        public async Task<FileResult> ImageDishCategory(int id)
        {
            var DishImage = await GetPlanillaImageContent(id, ImageFormat.Png, 200, 200);

            return File(DishImage, "image/png");
        }

        //
        public async Task<byte[]> GetAlumnoImageContent(int id, ImageFormat format, int maxWidth, int maxHeight)
        {
            var AlumnoImage = await db.Alumnoes.FindAsync(id);
            var img = AlumnoImage.Foto.ToImage();
            var scaleImage = img.ScaleImage(maxWidth, maxHeight);
            var stream = new MemoryStream();
            scaleImage.Save(stream, format);
            return stream.ToArray();
        }

        public byte[] GetInvoiceImageContent(byte[] id, ImageFormat format, int maxWidth, int maxHeight)
        {
            var img = id.ToImage();
            var scaleImage = img.ScaleImage(maxWidth, maxHeight);
            var stream = new MemoryStream();
            scaleImage.Save(stream, format);
            return stream.ToArray();
        }

        public async Task<byte[]> GetPlanillaImageContent(int id, ImageFormat format, int maxWidth, int maxHeight)
        {
            var planillImage = await db.Planillas.FindAsync(id);
            var img = planillImage.Foto.ToImage();
            var scaleImage = img.ScaleImage(maxWidth, maxHeight);
            var stream = new MemoryStream();
            scaleImage.Save(stream, format);
            return stream.ToArray();
        }
        // GET: Imagenes
        public ActionResult Index()
        {
            return View();
        }
    }
}