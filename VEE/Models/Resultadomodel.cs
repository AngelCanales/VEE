using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VEE.Models.BasedeDatos;

namespace VEE.Models
{
    public class Resultadomodel
    {
        public int Id { get; set; }

        public Planilla Planilla { get; set; }

        public int Votos { get; set; }

        public DateTime Fecha { get; set; }
        public string puesto { get; set; }
    }
}