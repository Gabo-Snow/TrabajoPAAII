using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MantencionAsignatura
    {
        private AcademicosEntities BDEntities = new AcademicosEntities();

        public bool Crear(Entidades.Asignatura asignatura)
        {
            try
            {
                BDEntities.Asignatura.Add(new Asignatura
                {
                    Asignatura1 = asignatura.Asignatura1,                    
                    Semestre = asignatura.Semestre,
                    IdCarrera = asignatura.IdCarrera
                   
                });
                BDEntities.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool Crear(Entidades.AsignaturaCarrera asignaturaCarrera)
        {
            try
            {
                BDEntities.Asignatura.Add(new Asignatura
                {
                    Asignatura1 = asignaturaCarrera.Asignatura.Asignatura1,
                    Semestre = asignaturaCarrera.Asignatura.Semestre,
                    IdCarrera = asignaturaCarrera.Asignatura.IdCarrera,
                    Carrera = new Carrera
                    {
                        Codigo = asignaturaCarrera.Carrera.Codigo,
                        NombreCarrera = asignaturaCarrera.Carrera.NombreCarrera,
                        AreaDeNegocio = asignaturaCarrera.Carrera.AreaNegocio,
                        Estado = asignaturaCarrera.Carrera.Estado
                    }
                });

                BDEntities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Entidades.Asignatura> ObtenerAsignaturas()
        {
            var _listaAsignaturas = (from a in BDEntities.Asignatura
                                     select a).ToList();
            
            List<Entidades.Asignatura> asignaturas = new List<Entidades.Asignatura>();

            foreach (var a in _listaAsignaturas)
            {
                asignaturas.Add(new Entidades.Asignatura
                {
                    IdAsignatura = a.IdAsignatura,
                    Asignatura1 = a.Asignatura1,
                    Semestre = a.Semestre
                });
            }
            return asignaturas;
        }


        public List<Entidades.Asignatura> GetAsignaturas()
        {
            List<Entidades.Asignatura> Asignatura = new List<Entidades.Asignatura>();
            try
            {
                var _listaAsignatura = BDEntities.Asignatura.ToList();

                foreach (var a in _listaAsignatura)
                {
                    Asignatura.Add(new Entidades.Asignatura
                    {
                        IdCarrera = a.IdCarrera,
                        IdAsignatura = a.IdAsignatura,
                        Asignatura1 = a.Asignatura1,                       
                        Semestre = a.Semestre                       

                    });

                }
                return Asignatura;
            }
            catch (System.Exception)
            {

                return Asignatura;
            }

        }
        
        public bool Actualizar(Entidades.Asignatura asignatura)
        {
            try
            {
                var _asignatura = BDEntities.Asignatura.First(a => a.IdAsignatura == asignatura.IdAsignatura);
                if (_asignatura != null)
                {
                    _asignatura.Asignatura1 = asignatura.Asignatura1;
                    _asignatura.Semestre = asignatura.Semestre;
                    _asignatura.IdCarrera = asignatura.IdCarrera;

                    BDEntities.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true; 
        }

        public Entidades.AsignaturaCarrera GetAsignaturaConCarreraId(int id)
        {
            var _asignatura = BDEntities.Asignatura.First(a => a.IdAsignatura == id);

            Entidades.AsignaturaCarrera asignaturaCarrera = new Entidades.AsignaturaCarrera
            {
                Asignatura = new Entidades.Asignatura
                {
                    IdAsignatura = _asignatura.IdAsignatura,
                    Asignatura1 = _asignatura.Asignatura1,
                    IdCarrera = _asignatura.IdCarrera,
                    Semestre = _asignatura.Semestre
                },
                Carrera = new Entidades.Carrera
                {
                    Id = _asignatura.Carrera.Id,
                    Codigo = _asignatura.Carrera.Codigo,
                    NombreCarrera = _asignatura.Carrera.NombreCarrera,
                    AreaNegocio = _asignatura.Carrera.AreaDeNegocio,                    
                    Estado = _asignatura.Carrera.Estado
                }
            };

            return asignaturaCarrera;
        }

        public bool Eliminar(int id)
        {
            try
            {
                var _asignatura = BDEntities.Asignatura.First(a => a.IdAsignatura == id);
                if (_asignatura != null)
                {
                    BDEntities.Asignatura.Remove(_asignatura);
                    BDEntities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }



    }
}
