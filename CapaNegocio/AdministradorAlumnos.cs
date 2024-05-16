using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AdministradorAlumnos
    {
        public bool Crear(Entidades.Alumno alumno)
        {

            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            
            return dataAlumnos.Crear(alumno);
        }
        public bool Eliminar(int id)
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            return dataAlumnos.Eliminar(id);

        }

        public List<Entidades.Alumno> GetAlumnos()
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            return dataAlumnos.GetAlumnos();
        }

        public bool Actualizar(Entidades.Alumno alumno)
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            return dataAlumnos.Actualizar(alumno);
        }

        public Entidades.Alumno GetAlumno (int id)
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            return dataAlumnos.GetAlumno(id);
        }


    }
}
