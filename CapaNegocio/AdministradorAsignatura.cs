using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AdministradorAsignatura
    {
        public List<Entidades.Asignatura> GetAsignaturas()
        {
            CapaDatos.MantencionAsignatura mantencionAsignatura= new CapaDatos.MantencionAsignatura();
            return mantencionAsignatura.ObtenerAsignaturas();
        }

        public List<Entidades.AsignaturaCarrera> GetaAsignaturasConCarreras()
        {
            CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
            return dataCarreras.GetAsignaturaConCarreras();
        }

        public Entidades.AsignaturaCarrera GetAsignaturaId(int idAsignatura)
        {
            CapaDatos.MantencionAsignatura mantencionAsignatura = new CapaDatos.MantencionAsignatura();
            return mantencionAsignatura.GetAsignaturaConCarreraId(idAsignatura);
        }
            
        public bool ActualizarAsignatura(Entidades.AsignaturaCarrera asignaturaCarrera)
        {
            CapaDatos.MantencionAsignatura mantencionAsignatura = new CapaDatos.MantencionAsignatura();
            bool result = mantencionAsignatura.Actualizar(asignaturaCarrera.Asignatura);

            if (result)
            {
                CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
                bool resultCarreras = dataCarreras.Actualizar(asignaturaCarrera.Carrera);

                return resultCarreras;
            }

            return false;
        }


        public bool Crear(Entidades.AsignaturaCarrera asignaturaCarrera)
        {
            CapaDatos.MantencionAsignatura mantencionAsignatura = new CapaDatos.MantencionAsignatura();
            if (mantencionAsignatura.Crear(asignaturaCarrera.Asignatura))
            {
                CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
                return dataCarreras.Crear(asignaturaCarrera.Carrera);
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            CapaDatos.MantencionAsignatura mantencionAsignatura = new CapaDatos.MantencionAsignatura();
            return mantencionAsignatura.Eliminar(id);  


        }
    }
}
