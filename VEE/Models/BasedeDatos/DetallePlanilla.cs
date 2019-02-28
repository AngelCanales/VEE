using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VEE.Models.BasedeDatos
{
    public class DetallePlanilla
    {
        [Key]
        public int Id { get; set; }
        public Planilla Planilla { get; set; }
        public CargoPlanilla CargoPlanilla { get; set; }
        public Alumno Alumno { get; set; }
    }
}