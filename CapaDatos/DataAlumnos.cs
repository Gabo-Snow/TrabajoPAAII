using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class DataAlumnos
    {
        private AcademicosEntities BDEntities = new AcademicosEntities();
        public bool Crear(Entidades.Alumno alumno)
        {
            try
            {
                BDEntities.Alumno.Add(new Alumno
                {
                    RUT = alumno.Rut,
                    Nombre = alumno.Nombre,
                    Apellidos = alumno.Apellido,
                    Edad = alumno.Edad,
                    Sexo = alumno.Sexo,
                    IdSalud = alumno.IdSalud

                });

                BDEntities.SaveChanges();


            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }
        /*     public bool Crear(Entidades.AlumnoDatosSalud alumnoDatosSalud)
             {
                 try
                 {
                     BDEntities.Alumno.Add(new Alumno
                     {
                         RUT = alumnoDatosSalud.Alumno.Rut,
                         Nombre = alumnoDatosSalud.Alumno.Nombre,
                         Apellidos = alumnoDatosSalud.Alumno.Apellido,
                         Edad = alumnoDatosSalud.Alumno.Edad,
                         Sexo = alumnoDatosSalud.Alumno.Sexo,
                         DatosSaludAlumno = new DatosSaludAlumno
                         {
                             Estatura = alumnoDatosSalud.DatosSaludAlumno.Estatura,
                             Peso = alumnoDatosSalud.DatosSaludAlumno.Peso,
                             ObservacionesSalud = alumnoDatosSalud.DatosSaludAlumno.ObservacionesSalud,
                             ProblemaCardiaco = alumnoDatosSalud.DatosSaludAlumno.ProblemaCardiaco
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
        public Entidades.Alumno GetAlumno(int id)
        {
            try
            {
                var alumno = BDEntities.Alumno.First(a => a.Id == id);

                if (alumno != null)
                {
                    Entidades.Alumno eAlumno = new Entidades.Alumno
                    {
                        Id = alumno.Id,
                        Rut = alumno.RUT,
                        Nombre = alumno.Nombre,
                        Apellido = alumno.Apellidos,
                        Edad = alumno.Edad,
                        Sexo = alumno.Sexo,
                        IdSalud = alumno.IdSalud
                    };
                    return eAlumno;
                }
                else
                {
                    return new Entidades.Alumno();
                }

            }
            catch (System.Exception)
            {

                return new Entidades.Alumno();
            }
        }

        public Entidades.Alumno GetAlumnoPorRut(string rutUsuario)
        {
            try
            {
                var alumno = BDEntities.Alumno.First(a => a.RUT == rutUsuario);

                if (alumno != null)
                {
                    Entidades.Alumno eAlumno = new Entidades.Alumno
                    {
                        Id = alumno.Id,
                        Rut = alumno.RUT,
                        Nombre = alumno.Nombre,
                        Apellido = alumno.Apellidos,
                        Edad = alumno.Edad,
                        Sexo = alumno.Sexo,
                        IdSalud =alumno.IdSalud,
                    };
                    return eAlumno;
                }
                else
                {
                    return new Entidades.Alumno();
                }

            }
            catch (System.Exception)
            {

                return new Entidades.Alumno();
            }
        }

        public List<Entidades.AlumnoDatosSalud> GetAlumnoConDatosSalud()
        {
            var _alumnos = BDEntities.Alumno
                                .Join(BDEntities.DatosSaludAlumno,
                                _alumno => _alumno.IdSalud,
                                _datosSaludAlumno => _datosSaludAlumno.IdSalud,
                                (_alumno, _datosSaludAlumno) => new
                                {
                                    _alumno,
                                    _datosSaludAlumno
                                }
                                ).ToList();

            List<Entidades.AlumnoDatosSalud> listaAlumnoDatosSalud = new List<Entidades.AlumnoDatosSalud>();

            foreach (var a in _alumnos)
            {
                listaAlumnoDatosSalud.Add(new Entidades.AlumnoDatosSalud
                {
                    Alumno = new Entidades.Alumno
                    {
                        Id = a._alumno.Id,
                        Rut = a._alumno.RUT,
                        Nombre = a._alumno.Nombre,
                        Apellido = a._alumno.Apellidos,
                        Edad = a._alumno.Edad,
                        Sexo = a._alumno.Sexo,
                        IdSalud = a._alumno.IdSalud

                    },
                    DatosSaludAlumno = new Entidades.DatosSaludAlumno
                    {
                        IdSalud = a._datosSaludAlumno.IdSalud,
                        Estatura = a._datosSaludAlumno.Estatura,
                        Peso = a._datosSaludAlumno.Peso,
                        ObservacionesSalud = a._datosSaludAlumno.ObservacionesSalud,
                        ProblemaCardiaco = a._datosSaludAlumno.ProblemaCardiaco
                    }
                });
            }
            return listaAlumnoDatosSalud;
        }

        public Entidades.AlumnoDatosSalud GetAlumnoConDatosSaludId(int id)
        {
            var _alumno = BDEntities.Alumno.First(a => a.Id == id);

            Entidades.AlumnoDatosSalud alumnoDatosSalud = new AlumnoDatosSalud
            {
                Alumno = new Entidades.Alumno
                {
                    Id = _alumno.Id,
                    Rut = _alumno.RUT,
                    Nombre = _alumno.Nombre,
                    Apellido = _alumno.Apellidos,
                    Edad = _alumno.Edad,
                    Sexo = _alumno.Sexo,
                    IdSalud = _alumno.IdSalud
                   
                },
                DatosSaludAlumno = new Entidades.DatosSaludAlumno
                {
                    IdSalud = _alumno.DatosSaludAlumno1.IdSalud,
                    Estatura = _alumno.DatosSaludAlumno1.Estatura,
                    Peso = _alumno.DatosSaludAlumno1.Estatura,
                    ObservacionesSalud = _alumno.DatosSaludAlumno1.ObservacionesSalud,
                    ProblemaCardiaco = _alumno.DatosSaludAlumno1.ProblemaCardiaco
                }

            };
            return alumnoDatosSalud;
        }
        public bool Actualizar(Entidades.Alumno alumno)
        {
            try
            {
                var _alumno = BDEntities.Alumno.First(a => a.Id == alumno.Id);
                if (_alumno != null)
                {
                    _alumno.RUT = alumno.Rut;
                    _alumno.Nombre = alumno.Nombre;
                    _alumno.Apellidos = alumno.Apellido;
                    _alumno.Edad = alumno.Edad;
                    _alumno.Sexo = alumno.Sexo;
                    _alumno.IdSalud = alumno.IdSalud;

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

        public bool Eliminar(int id)
        {
            try
            {
                var _alumno = BDEntities.Alumno.First(a => a.Id == id);
                if (_alumno != null)
                {
                    BDEntities.Alumno.Remove(_alumno);
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

        public List<Entidades.Alumno> GetAlumnos()
        {
            List<Entidades.Alumno> listaAlumnosNegocio = new List<Entidades.Alumno>();
            try
            {
                var _listaAlumnos = BDEntities.Alumno.ToList();

                foreach (var a in _listaAlumnos)
                {
                    listaAlumnosNegocio.Add(new Entidades.Alumno
                    {
                        Id = a.Id,
                        Rut = a.RUT,
                        Nombre = a.Nombre,
                        Apellido = a.Apellidos,
                        Edad = a.Edad,
                        Sexo = a.Sexo,
                        IdSalud = a.IdSalud
                    });

                }
                return listaAlumnosNegocio;
            }
            catch (System.Exception)
            {

                return listaAlumnosNegocio;
            }

        }



    }
}
