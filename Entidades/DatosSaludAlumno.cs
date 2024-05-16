using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DatosSaludAlumno
    {
        public int IdSalud { get; set; }
        public int Estatura { get; set; }
        public int Peso { get; set; }
        public string ObservacionesSalud { get; set; }
        public bool? ProblemaCardiaco { get; set; } 

    }
}
