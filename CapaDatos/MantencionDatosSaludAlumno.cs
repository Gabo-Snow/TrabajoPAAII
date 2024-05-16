using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class MantencionDatosSaludAlumno
    {
        private AcademicosEntities BDEntities = new AcademicosEntities();

        public bool Crear(Entidades.DatosSaludAlumno datosSaludAlumno)
        {
            try
            {
                BDEntities.DatosSaludAlumno.Add(new DatosSaludAlumno
                {
                    IdSalud = datosSaludAlumno.IdSalud,                
                    Estatura = datosSaludAlumno.Estatura,
                    Peso = datosSaludAlumno.Peso,
                    ObservacionesSalud = datosSaludAlumno.ObservacionesSalud,
                    ProblemaCardiaco = datosSaludAlumno.ProblemaCardiaco

                });
                BDEntities.SaveChanges();
            }

            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Crear(Entidades.AlumnoDatosSalud alumnoDatosSalud)
        {
            try
            {
                BDEntities.Alumno.Add(new Alumno
                {
                    
                    Apellidos = alumnoDatosSalud.Alumno.Apellido,
                    Edad =  alumnoDatosSalud.Alumno.Edad,
                    IdSalud = alumnoDatosSalud.Alumno.IdSalud,
                    Nombre = alumnoDatosSalud.Alumno.Nombre,
                    RUT = alumnoDatosSalud.Alumno.Nombre,
                    Sexo = alumnoDatosSalud.Alumno.Sexo,
                    DatosSaludAlumno1 = new DatosSaludAlumno
                    {
                        Estatura = alumnoDatosSalud.DatosSaludAlumno.Estatura,
                        ObservacionesSalud = alumnoDatosSalud.DatosSaludAlumno.ObservacionesSalud,
                        Peso = alumnoDatosSalud.DatosSaludAlumno.Peso,
                        ProblemaCardiaco = alumnoDatosSalud.DatosSaludAlumno.ProblemaCardiaco,
                        
                    }
                });

                BDEntities.SaveChanges();
            }
            catch (System.Exception)
            {

                return true;
            }

            return true;
        }   

        public List<Entidades.DatosSaludAlumno> ObtenerDatosSalud()
        {
            var _listaDatosSaludAlumno = (from d in BDEntities.DatosSaludAlumno
                                          select d).ToList();
            List<Entidades.DatosSaludAlumno> DatosSaludAlumno = new List<Entidades.DatosSaludAlumno>();

            foreach (var d in _listaDatosSaludAlumno)
            {
                DatosSaludAlumno.Add(new Entidades.DatosSaludAlumno
                {
                    IdSalud = d.IdSalud,
                    Estatura = d.Estatura,
                    Peso = d.Peso,
                    ObservacionesSalud = d.ObservacionesSalud,
                    ProblemaCardiaco = d.ProblemaCardiaco
                });

            }
            return DatosSaludAlumno;

        }

        public List<Entidades.DatosSaludAlumno> GetDatosSaludAlumno()
        {
            List<Entidades.DatosSaludAlumno> DatosSaludAlumno = new List<Entidades.DatosSaludAlumno>();
            try
            {
                var _listaDatosSaludAlumnos = BDEntities.DatosSaludAlumno.ToList();

                foreach (var d in _listaDatosSaludAlumnos)
                {
                    DatosSaludAlumno.Add(new Entidades.DatosSaludAlumno
                    {
                        IdSalud = d.IdSalud,
                        Estatura = d.Estatura,
                        Peso = d.Peso,
                        ObservacionesSalud = d.ObservacionesSalud,
                        ProblemaCardiaco = d.ProblemaCardiaco


                        
                });


                }
                return DatosSaludAlumno;
            }
            catch (System.Exception)
            {

                return DatosSaludAlumno;
            }
        }
        public bool Actualizar(Entidades.DatosSaludAlumno datosSaludAlumno)
        {
            try
            {
                var _datosSaludAlumno = BDEntities.DatosSaludAlumno.First(d => d.IdSalud == datosSaludAlumno.IdSalud);
                if (_datosSaludAlumno != null)
                {
                    _datosSaludAlumno.Estatura = datosSaludAlumno.Estatura;
                    _datosSaludAlumno.Peso = datosSaludAlumno.Peso;
                    _datosSaludAlumno.ObservacionesSalud = datosSaludAlumno.ObservacionesSalud;
                    _datosSaludAlumno.ProblemaCardiaco = datosSaludAlumno.ProblemaCardiaco;

                    BDEntities.SaveChanges();

                    return true;
                }
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Eliminar(int id)
        {
            try
            {
                var _datosSaludAlumno = BDEntities.DatosSaludAlumno.First(d => d.IdSalud == id);
                if (_datosSaludAlumno != null)
                {
                    BDEntities.DatosSaludAlumno.Remove(_datosSaludAlumno);
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
    }
}
