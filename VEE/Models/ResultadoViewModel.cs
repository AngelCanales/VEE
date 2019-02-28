using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VEE.Models.BasedeDatos;

namespace VEE.Models
{
    public class ResultadoViewModel
    {
        public IEnumerable<Resultadomodel> Resultados { get; set; }
    }
}