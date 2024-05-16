using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string Asignatura1 { get; set; }
        public int Semestre { get; set; }
        public int IdCarrera { get; set; }
    }

    public class AsignaturaCarrera
    {
        public Asignatura Asignatura = new Asignatura();
        public Carrera Carrera = new Carrera();
    }

}
