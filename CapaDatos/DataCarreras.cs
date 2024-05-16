using System.Collections.Generic;
using System.Data.Entity.Core.Common;
using System.Linq;

namespace CapaDatos
{
    public class DataCarreras
    {
        private AcademicosEntities BDEntities = new AcademicosEntities();
        public bool Crear(Entidades.Carrera carrera)
        {
            try
            {
                BDEntities.Carrera.Add(new Carrera
                {
                    Codigo = carrera.Codigo,
                    NombreCarrera = carrera.NombreCarrera,
                    AreaDeNegocio = carrera.AreaNegocio,
                    Estado = carrera.Estado

                });
                BDEntities.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
           

        }
/*
        public bool Crear(Entidades.CarreraAsignatura carreraAsignatura)
        {
            try
            {
                BDEntities.Carrera.Add(new Carrera
                {
                    Codigo = carreraAsignatura.Carrera.Codigo,
                    NombreCarrera = carreraAsignatura.Carrera.NombreCarrera,
                    AreaDeNegocio = carreraAsignatura.Carrera.AreaNegocio,
                    Estado = carreraAsignatura.Carrera.Estado,
                    Asignatura = new Asignatura
                    {
                        IdAsignatura = carreraAsignatura.Asignatura.IdAsignatura,
                        Asignatura1 = carreraAsignatura.Asignatura.Asignatura1,
                        Semestre = carreraAsignatura.Asignatura.Semestre
                    }
                });
                BDEntities.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;

        }
*/
        public Entidades.Carrera GetCarrera(int id)
        {
            try
            {
                var carrera = BDEntities.Carrera.First(a => a.Id == id);

                if (carrera != null)
                {
                    Entidades.Carrera eCarrera = new Entidades.Carrera
                    {
                        Id = carrera.Id,
                        Codigo = carrera.Codigo,
                        NombreCarrera = carrera.NombreCarrera,
                        AreaNegocio = carrera.AreaDeNegocio,
                        Estado = carrera.Estado                        
                        
                    };
                    return eCarrera;
                }
                else
                {
                    return new Entidades.Carrera();
                }

            }
            catch (System.Exception)
            {

                return new Entidades.Carrera();
            }
        }


        public Entidades.Carrera GetCarreraPorCodigo(string codigoCarrera)
        {
            try
            {
                var carrera = BDEntities.Carrera.First(a => a.Codigo == codigoCarrera);

                if (carrera != null)
                {
                    Entidades.Carrera eCarrera = new Entidades.Carrera
                    {
                        Id = carrera.Id,
                        Codigo = carrera.Codigo,
                        NombreCarrera = carrera.NombreCarrera,
                        AreaNegocio = carrera.AreaDeNegocio,
                        Estado = carrera.Estado

                    };
                    return eCarrera;
                }
                else
                {
                    return new Entidades.Carrera();
                }

            }
            catch (System.Exception)
            {

                return new Entidades.Carrera();
            }
        }

        public List<Entidades.AsignaturaCarrera> GetAsignaturaConCarreras()
        {
            var _asignaturas = BDEntities.Asignatura
                                .Join(BDEntities.Carrera,
                                _asignatura => _asignatura.IdAsignatura,
                                _carrera => _carrera.Id,
                                (_asignatura, _carrera) => new
                                {
                                    _asignatura,
                                    _carrera
                                }
                                ).ToList();

            List<Entidades.AsignaturaCarrera> listaAsignaturaCarreras = new List<Entidades.AsignaturaCarrera>();

            foreach (var a in _asignaturas)
            {
                listaAsignaturaCarreras.Add(new Entidades.AsignaturaCarrera
                {
                    Asignatura = new Entidades.Asignatura
                    {
                        IdAsignatura = a._asignatura.IdAsignatura,
                        Asignatura1 = a._asignatura.Asignatura1,
                        IdCarrera = a._asignatura.IdCarrera,
                        Semestre = a._asignatura.Semestre
                        
                    },
                    Carrera = new Entidades.Carrera
                    {
                        Id = a._carrera.Id,
                        Codigo = a._carrera.Codigo,
                        NombreCarrera = a._carrera.NombreCarrera,
                        AreaNegocio = a._carrera.AreaDeNegocio,
                        Estado = a._carrera.Estado
                    }                    
                });
            }
            return listaAsignaturaCarreras;
        }

        public  bool Actualizar(Entidades.Carrera carrera)
        {
            try
            {
                var _carrera = BDEntities.Carrera.First(c => c.Id == carrera.Id);
                if (_carrera != null)
                {
                    _carrera.Codigo = carrera.Codigo;
                    _carrera.NombreCarrera = carrera.NombreCarrera;
                    _carrera.AreaDeNegocio = carrera.AreaNegocio;
                    _carrera.Estado = carrera.Estado;

                    BDEntities.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Exception)
            {

                return false; ;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var _carreras = BDEntities.Carrera.First(c => c.Id == id);

                if (_carreras != null)
                {
                    BDEntities.Carrera.Remove(_carreras);
                    BDEntities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {

                return false;
            }

        }

        public List<Entidades.Carrera> GetCarreras()
        {

            
            List<Entidades.Carrera> listaCarreraNegocio = new List<Entidades.Carrera>();

            try
            {
                var _listaCarreras = BDEntities.Carrera.ToList();

                foreach (var c in _listaCarreras)
                {
                    listaCarreraNegocio.Add(new Entidades.Carrera
                    {
                        Id = c.Id,
                        Codigo = c.Codigo,
                        NombreCarrera = c.NombreCarrera,
                        AreaNegocio = c.AreaDeNegocio,
                        Estado = c.Estado

                    });

                }

                return listaCarreraNegocio;
            }
            catch (System.Exception)
            {

                return listaCarreraNegocio;
            }

           
        }
         public Entidades.AsignaturaCarrera GetAsignaturaConCarreraId(int id)
        {
            var _asignatura = BDEntities.Asignatura.First(a => a.IdAsignatura == id);

            Entidades.AsignaturaCarrera asignaturaCarrera = new Entidades.AsignaturaCarrera
            {
                Asignatura = new Entidades.Asignatura
                {
                    IdAsignatura = _asignatura.IdAsignatura,
                    Asignatura1 =  _asignatura.Asignatura1,
                    IdCarrera = _asignatura.IdCarrera,
                    Semestre = _asignatura.Semestre
                },
                Carrera = new Entidades.Carrera
                {
                    Id = _asignatura.Carrera.Id,
                    Codigo = _asignatura.Carrera.Codigo,
                    NombreCarrera = _asignatura.Carrera.NombreCarrera,
                    AreaNegocio = _asignatura.Carrera.Codigo,
                    Estado  = _asignatura.Carrera.Estado
                }               

            };

            return asignaturaCarrera;
        }
        
    }
}
