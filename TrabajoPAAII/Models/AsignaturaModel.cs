using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabajoPAAII.Models
{
    public class AsignaturaModel
    {
        [DisplayName("Id Asignatura")] 
        public int IdAsignatura { get; set; }
        [Required]
        [DisplayName("Nombre Asignatura")]
        public string Asignatura1 { get; set; }
        [Required]
        [Range(1, 10)]
        public int Semestre { get; set; }
        [Required]
        [DisplayName("Carrera")]
        public int IdCarrera { get; set; }


    } 

    public class AsignaturaCarreraModel
    {
        //public AsignaturaModel AsignaturaModel = new AsignaturaModel();
        public AsignaturaModel AsignaturaModel { get; set; }
        //public CarreraModel CarreraModel = new CarreraModel();
        public CarreraModel CarreraModel { get; set; }
    }
}