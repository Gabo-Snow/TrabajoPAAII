using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Rut { get; set; }     
        public string Nombre { get; set; }      
        public string Apellido { get; set; }
        public int Edad { get; set; }        
        public int Sexo { get; set; }
        public int? IdSalud { get; set; }


    }
    public class AlumnoDatosSalud
    {
        public Alumno Alumno = new Alumno();
        public DatosSaludAlumno DatosSaludAlumno = new DatosSaludAlumno();
    }
}
