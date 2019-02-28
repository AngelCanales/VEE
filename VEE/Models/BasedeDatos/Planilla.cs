using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VEE.Models.BasedeDatos
{
    public class Planilla
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Error el campo {0} esta vacio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Foto"), DataType(DataType.Upload, ErrorMessage = "Images not valid")]
        public byte[] Foto { get; set; }
    }
}