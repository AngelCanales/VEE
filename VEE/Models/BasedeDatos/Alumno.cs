using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VEE.Models.BasedeDatos
{
   public class Alumno
    {
        [Key]
        public int IdAlumno  { get; set; }
        public Escuela Escuela { get; set; }

        public Grado Grado { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public byte[] Foto { get; set; }

    }
}