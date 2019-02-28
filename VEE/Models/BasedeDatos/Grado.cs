using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VEE.Models.BasedeDatos
{
    public class Grado
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}