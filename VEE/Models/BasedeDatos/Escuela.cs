using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VEE.Models.BasedeDatos
{
    public class Escuela
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public string Dirreccion { get; set; }

        public string Telefono { get; set; }
    }
}