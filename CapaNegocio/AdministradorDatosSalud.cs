using Entidades;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class AdministradorDatosSalud
    {
        public List<Entidades.DatosSaludAlumno> GetDatosSaludAlumnos()
        {
            CapaDatos.MantencionDatosSaludAlumno mantencionDatosSaludAlumno = new CapaDatos.MantencionDatosSaludAlumno();
            return mantencionDatosSaludAlumno.ObtenerDatosSalud();
        }

        public List<Entidades.AlumnoDatosSalud> GetAlumnoConDatosSalud()
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            return dataAlumnos.GetAlumnoConDatosSalud();
        }

        public Entidades.AlumnoDatosSalud GetAlumnoDatosSaludId(int id)
        {
            CapaDatos.DataAlumnos alumno = new CapaDatos.DataAlumnos();
            return alumno.GetAlumnoConDatosSaludId(id);
        }
        public bool ActualizarAlumnoConDatosSalud(Entidades.AlumnoDatosSalud alumnoDatosSalud)
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            bool result = dataAlumnos.Actualizar(alumnoDatosSalud.Alumno);

            if (result)
            {
                CapaDatos.MantencionDatosSaludAlumno mantencionDatosSaludAlumno = new CapaDatos.MantencionDatosSaludAlumno();
                bool resultDatosSalud = mantencionDatosSaludAlumno.Actualizar(alumnoDatosSalud.DatosSaludAlumno);

                return resultDatosSalud;
            }

            return false;
        }

        public bool Crear(AlumnoDatosSalud alumnoDatosSalud)
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            if (dataAlumnos.Crear(alumnoDatosSalud.Alumno))
            {
                CapaDatos.MantencionDatosSaludAlumno mantencionDatosSaludAlumno = new CapaDatos.MantencionDatosSaludAlumno();
                return mantencionDatosSaludAlumno.Crear(alumnoDatosSalud.DatosSaludAlumno);
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
            return dataAlumnos.Eliminar(id);
        }
        //public bool Crear2(AlumnoDatosSalud alumnoDatosSalud)
        //{
        //    CapaDatos.DataAlumnos dataAlumnos = new CapaDatos.DataAlumnos();
        //    return dataAlumnos.Crear(alumnoDatosSalud);
        //}
    }
}
