using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AdministradorCarreras
    {
        public bool Crear(Entidades.Carrera carrera)
        {
            CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
            
            return dataCarreras.Crear(carrera);
        }
        public bool Eliminar(int id)
        {
            CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();

            return dataCarreras.Eliminar(id);
        }

        public List<Entidades.Carrera> GetCarreras()
        {
            CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
            return dataCarreras.GetCarreras();
        }

        public bool Actualizar(Entidades.Carrera carrera)
        {
            CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
            return dataCarreras.Actualizar(carrera);
        }

        public Entidades.Carrera GetCarrera(int id)
        {
            CapaDatos.DataCarreras dataCarreras = new CapaDatos.DataCarreras();
            return dataCarreras.GetCarrera(id);
        }

        
    }
}
