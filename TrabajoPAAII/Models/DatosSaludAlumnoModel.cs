using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabajoPAAII.Models
{
    public class DatosSaludAlumnoModel
    {
        [DisplayName("Id Salud")]
        public int IdSalud { get; set; }
        [Required]
        [Range(0, 500)]
        public int Estatura { get; set; }
        [Required]
        [Range(0, 500)]
        public int Peso { get; set; }
        [Required]
        [DisplayName("Observaciones de Salud")]
        public string ObservacionesSalud { get; set; }
        [Required]
        [DisplayName("¿Problema Cardiaco?")]
        public bool? ProblemaCardiaco { get; set; }
    }
}