using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VEE.Models.BasedeDatos;
using System.Web.Mvc;
namespace VEE.Models
{
    public class AlumnoViewModels
    {
        [Key]
        public int IdAlumno { get; set; }

        [Required]
        public int IdEscuela { get; set; }
        public IEnumerable<Escuela> Escuela { get; set; }

        [Required]
        public  int IdGrado  { get; set; }
        public IEnumerable<Grado> Grado { get; set; }

        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }


        [Display(Name = "Foto"), DataType(DataType.Upload, ErrorMessage = "Images not valid")]
        public byte[] Image { get; set; }
    }
 }