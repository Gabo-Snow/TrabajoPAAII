using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace TrabajoPAAII.Models
{
    public class AlumnoModel
    {
     
        public int Id { get; set; }

        [Required (ErrorMessage ="Debe ingresar un RUT")]
        [DataType(DataType.Text)]
        [StringLength(12),MinLength(6, ErrorMessage = "El Mínimo de carácteres es 6")]

        public string Rut { get; set; }

        [Required(ErrorMessage ="Debe ingresar un Nombre")]
        [DataType(DataType.Text)]
        [StringLength(100), MinLength(3, ErrorMessage = "El Mínimo de carácteres es 3")]

        public string Nombre { get; set; }

        [Required(ErrorMessage ="Debe ingresar un Apellido")]
        [DataType(DataType.Text)]
        [StringLength(100), MinLength(3, ErrorMessage = "El Mínimo de carácteres es 3")]

        public string Apellido { get; set; }

        [Required(ErrorMessage ="Debe ingresar la edad")]
        [Range(15,110)]
        public int Edad { get; set; }

        [DisplayName("Sexo: 1 = Masc, 2 = Fem.")]
        [Required(ErrorMessage ="Debe ingresar Sexo")]
        [Range(1,2)]
        public int Sexo { get; set; }

        public int? IdSalud { get; set; }

    }

    public class AlumnoDatosSaludModel
    {
        //public AlumnoModel AlumnoModel = new AlumnoModel();
        public AlumnoModel AlumnoModel { get; set; } 
        //public DatosSaludAlumnoModel DatosSaludAlumnoModel = new DatosSaludAlumnoModel();
        public DatosSaludAlumnoModel DatosSaludAlumnoModel { get; set; }
    }
}