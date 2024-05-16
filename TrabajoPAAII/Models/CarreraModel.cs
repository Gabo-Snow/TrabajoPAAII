using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Entidades;

namespace TrabajoPAAII.Models
{
    public class CarreraModel
    {
        public int Id { get; set; }

        [DisplayName("Código Carrera")]
        [Required]
        public string Codigo { get; set; }
        [DisplayName("Nombre de la Carrera")]
        [Required]
        public string NombreCarrera { get; set; }

        [DisplayName("Área de Negocio")]
        [Required]
        public string AreaNegocio { get; set; }

        public bool Estado { get; set; }
    }

    public class CarreraAsignaturaModel
    {
        public CarreraModel CarreraModel = new CarreraModel();
        public AsignaturaModel AsignaturaModel = new AsignaturaModel();
    }
}