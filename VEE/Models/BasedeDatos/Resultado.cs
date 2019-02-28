using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VEE.Models.BasedeDatos
{
    public class Resultado
    {
        public int Id { get; set; }

        public Planilla Planilla { get; set; }

        public int Votos { get; set; }

        public DateTime Fecha { get; set; }
    }
}