using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPAAII.Models;

namespace TrabajoPAAII.Controllers
{
    public class AdminDatosSaludAlumnoController : Controller
    {
        // GET: AdminDatosSaludAlumno
        public ActionResult Index()
        {
            CapaNegocio.AdministradorDatosSalud administradorDatosSalud = new CapaNegocio.AdministradorDatosSalud();
            var alumnoConDatosSalud = administradorDatosSalud.GetAlumnoConDatosSalud();

            List<Models.AlumnoDatosSaludModel> listaAlumnoDatosSalud = new List<Models.AlumnoDatosSaludModel>();

            foreach (var a in  alumnoConDatosSalud)
            {
                listaAlumnoDatosSalud.Add(new Models.AlumnoDatosSaludModel
                {
                    AlumnoModel = new Models.AlumnoModel
                    {
                        Id = a.Alumno.Id,
                        Rut = a.Alumno.Rut,
                        Nombre = a.Alumno.Nombre,
                        Apellido = a.Alumno.Apellido,
                        Edad = a.Alumno.Edad,
                        Sexo = a.Alumno.Sexo,
                        IdSalud = a.Alumno.IdSalud
                        
                    },
                    DatosSaludAlumnoModel = new Models.DatosSaludAlumnoModel
                    {
                        IdSalud = a.DatosSaludAlumno.IdSalud,
                        Estatura = a.DatosSaludAlumno.Estatura,
                        Peso = a.DatosSaludAlumno.Peso,
                        ObservacionesSalud = a.DatosSaludAlumno.ObservacionesSalud,
                        ProblemaCardiaco = a.DatosSaludAlumno.ProblemaCardiaco
                    }
                });
            
            }

            return View(listaAlumnoDatosSalud);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            #region Dropdownlist

            var listaDatosSalud = GetDatosSaludAlumno();
            List<SelectListItem> selectListItems = listaDatosSalud.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.ObservacionesSalud,
                    Value = l.IdSalud.ToString()
                };
            });

            #endregion

            return View(new Models.AlumnoDatosSaludModel());
        }

        [HttpPost]
        public ActionResult Crear(Models.AlumnoDatosSaludModel model)
        {
            Entidades.AlumnoDatosSalud alumnoDatosSalud = new Entidades.AlumnoDatosSalud
            {
                Alumno = new Entidades.Alumno
                {
                    Apellido = model.AlumnoModel.Apellido,
                    Edad = model.AlumnoModel.Edad,
                    IdSalud = model.AlumnoModel.IdSalud,
                    Nombre = model.AlumnoModel.Nombre,
                    Rut = model.AlumnoModel.Rut,
                    Sexo = model.AlumnoModel.Sexo
                },
                DatosSaludAlumno = new Entidades.DatosSaludAlumno
                {
                    Estatura = model.DatosSaludAlumnoModel.Estatura,
                    ObservacionesSalud = model.DatosSaludAlumnoModel.ObservacionesSalud,
                    Peso = model.DatosSaludAlumnoModel.Peso,
                    ProblemaCardiaco = model.DatosSaludAlumnoModel.ProblemaCardiaco
                }
            };

            CapaNegocio.AdministradorDatosSalud administradorDatosSalud = new CapaNegocio.AdministradorDatosSalud();

            if (administradorDatosSalud.Crear(alumnoDatosSalud))
            {
                return RedirectToAction("Index");
            }

            #region DropdownList

            var listaDatosSalud = GetDatosSaludAlumno();

            List<SelectListItem> selectListItems = listaDatosSalud.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.ObservacionesSalud,
                    Value = l.IdSalud.ToString()
                };
            });

            ViewBag.ListaDatosSalud = selectListItems;

            #endregion

            return View(model);


        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            CapaNegocio.AdministradorDatosSalud administradorDatosSalud = new CapaNegocio.AdministradorDatosSalud();
            var _producto = administradorDatosSalud.GetAlumnoDatosSaludId(id);

            Models.AlumnoDatosSaludModel alumnoDatosSaludModel = new Models.AlumnoDatosSaludModel
            {
                AlumnoModel = new Models.AlumnoModel
                {
                    Id = _producto.Alumno.Id,
                    Rut = _producto.Alumno.Rut,
                    Nombre = _producto.Alumno.Nombre,
                    Apellido = _producto.Alumno.Apellido,
                    Edad = _producto.Alumno.Edad,
                    Sexo = _producto.Alumno.Sexo,
                    IdSalud = _producto.Alumno.IdSalud
                },
                DatosSaludAlumnoModel = new DatosSaludAlumnoModel
                {
                    IdSalud = _producto.DatosSaludAlumno.IdSalud,
                    Estatura = _producto.DatosSaludAlumno.Estatura,
                    Peso = _producto.DatosSaludAlumno.Peso,
                    ProblemaCardiaco = _producto.DatosSaludAlumno.ProblemaCardiaco,
                    ObservacionesSalud = _producto.DatosSaludAlumno.ObservacionesSalud
                }

            };
                
            var listaDatosSaludAlumno = GetDatosSaludAlumno();

            List<SelectListItem> selectListItems = listaDatosSaludAlumno.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.ObservacionesSalud.ToString(),                       
                    Value = l.IdSalud.ToString(),
                    Selected = l.IdSalud == alumnoDatosSaludModel.AlumnoModel.IdSalud ? true : false
                };
            });

            ViewBag.ListaDatosSalud = selectListItems;

            return View(alumnoDatosSaludModel);
        }

        [HttpPost]
        public ActionResult Editar(Models.AlumnoDatosSaludModel model)
        {
            CapaNegocio.AdministradorDatosSalud administradorDatosSalud= new CapaNegocio.AdministradorDatosSalud();
            bool result = administradorDatosSalud.ActualizarAlumnoConDatosSalud(new Entidades.AlumnoDatosSalud
            {
                Alumno = new Entidades.Alumno
                {
                    Id = model.AlumnoModel.Id,
                    Rut = model.AlumnoModel.Rut,
                    Apellido = model.AlumnoModel.Apellido,
                    Edad = model.AlumnoModel.Edad,
                    IdSalud = model.AlumnoModel.IdSalud,
                    Nombre =  model.AlumnoModel.Nombre,
                    Sexo =  model.AlumnoModel.Sexo
                },
                DatosSaludAlumno = new Entidades.DatosSaludAlumno
                {
                    IdSalud = model.DatosSaludAlumnoModel.IdSalud,
                    Estatura = model.DatosSaludAlumnoModel.IdSalud,
                    ObservacionesSalud = model.DatosSaludAlumnoModel.ObservacionesSalud,
                    Peso = model.DatosSaludAlumnoModel.Peso,
                    ProblemaCardiaco = model.DatosSaludAlumnoModel.ProblemaCardiaco

                }

            });

            if (result)
            {
                return RedirectToAction("Index");
            }

            var _alumno = administradorDatosSalud.GetAlumnoDatosSaludId(model.AlumnoModel.Id);

            Models.AlumnoDatosSaludModel alumnoDatosSaludModel= new Models.AlumnoDatosSaludModel
            {
                AlumnoModel = new Models.AlumnoModel
                {
                    Id = _alumno.Alumno.Id,
                    Apellido = _alumno.Alumno.Apellido,
                    Edad =  _alumno.Alumno.Edad,
                    IdSalud = _alumno.Alumno.IdSalud,
                    Nombre = _alumno.Alumno.Nombre,
                    Rut = _alumno.Alumno.Rut,
                    Sexo = _alumno.Alumno.Sexo
                },
                DatosSaludAlumnoModel = new Models.DatosSaludAlumnoModel
                {
                    IdSalud = _alumno.DatosSaludAlumno.IdSalud,
                    Estatura = _alumno.DatosSaludAlumno.Estatura,  
                    ObservacionesSalud = _alumno.DatosSaludAlumno.ObservacionesSalud,
                    Peso =  _alumno.DatosSaludAlumno.Peso,
                    ProblemaCardiaco = _alumno.DatosSaludAlumno.ProblemaCardiaco
                }
            };

            #region dropdownlist    

            var listaDatosSaludAlumno = GetDatosSaludAlumno();

            List<SelectListItem> selectListItems = listaDatosSaludAlumno.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.ObservacionesSalud.ToString(),
                    Value = l.IdSalud.ToString(),
                    Selected = l.IdSalud == alumnoDatosSaludModel.AlumnoModel.IdSalud ? true : false
                };
            });

            ViewBag.ListaDatosSalud = selectListItems;

            #endregion

            return View(alumnoDatosSaludModel);
           

        }
        public ActionResult Detalle(int id)
        {
            CapaNegocio.AdministradorDatosSalud administradorDatosSalud = new CapaNegocio.AdministradorDatosSalud();
            var _producto = administradorDatosSalud.GetAlumnoDatosSaludId(id);

            Models.AlumnoDatosSaludModel alumnoDatosSaludModel = new Models.AlumnoDatosSaludModel
            {
                AlumnoModel = new Models.AlumnoModel
                {
                    Id = _producto.Alumno.Id,
                    Rut = _producto.Alumno.Rut,
                    Nombre = _producto.Alumno.Nombre,
                    Apellido = _producto.Alumno.Apellido,
                    Edad = _producto.Alumno.Edad,
                    Sexo = _producto.Alumno.Sexo,
                    IdSalud = _producto.Alumno.IdSalud
                },
                DatosSaludAlumnoModel = new DatosSaludAlumnoModel
                {
                    IdSalud = _producto.DatosSaludAlumno.IdSalud,
                    Estatura = _producto.DatosSaludAlumno.Estatura,
                    Peso = _producto.DatosSaludAlumno.Peso,
                    ProblemaCardiaco = _producto.DatosSaludAlumno.ProblemaCardiaco,
                    ObservacionesSalud = _producto.DatosSaludAlumno.ObservacionesSalud
                }

            };

        
            return View(alumnoDatosSaludModel);
        }

        [HttpPost]
        public ActionResult Detalle(AlumnoDatosSaludModel alumnoDatosSaludModel)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();
            if (administradorAlumnos.Eliminar(alumnoDatosSaludModel.AlumnoModel.Id))
            {
                CapaNegocio.AdministradorDatosSalud administradorDatosSalud= new CapaNegocio.AdministradorDatosSalud();
                if (administradorDatosSalud.Eliminar(alumnoDatosSaludModel.DatosSaludAlumnoModel.IdSalud))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public List<Models.DatosSaludAlumnoModel> GetDatosSaludAlumno()
        {
            CapaNegocio.AdministradorDatosSalud administradorDatosSalud = new CapaNegocio.AdministradorDatosSalud();
            var _ = administradorDatosSalud.GetDatosSaludAlumnos();

            List<Models.DatosSaludAlumnoModel> datosSaludAlumnoModels = new List<Models.DatosSaludAlumnoModel>();

            foreach (var d in _)
            {
                datosSaludAlumnoModels.Add(new Models.DatosSaludAlumnoModel
                {
                    IdSalud = d.IdSalud,
                    Estatura = d.Estatura,                    
                    Peso = d.Peso,
                    ProblemaCardiaco = d.ProblemaCardiaco,
                    ObservacionesSalud = d.ObservacionesSalud
                });
            }
            return datosSaludAlumnoModels;
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            CapaNegocio.AdministradorDatosSalud administradorDatosSalud = new CapaNegocio.AdministradorDatosSalud();
            var _producto = administradorDatosSalud.GetAlumnoDatosSaludId(id);

            Models.AlumnoDatosSaludModel alumnoDatosSaludModel = new Models.AlumnoDatosSaludModel
            {
                AlumnoModel = new Models.AlumnoModel
                {
                    Id = _producto.Alumno.Id,
                    Rut = _producto.Alumno.Rut,
                    Nombre = _producto.Alumno.Nombre,
                    Apellido = _producto.Alumno.Apellido,
                    Edad = _producto.Alumno.Edad,
                    Sexo = _producto.Alumno.Sexo,
                    IdSalud = _producto.Alumno.IdSalud
                },
                DatosSaludAlumnoModel = new DatosSaludAlumnoModel
                {
                    IdSalud = _producto.DatosSaludAlumno.IdSalud,
                    Estatura = _producto.DatosSaludAlumno.Estatura,
                    Peso = _producto.DatosSaludAlumno.Peso,
                    ProblemaCardiaco = _producto.DatosSaludAlumno.ProblemaCardiaco,
                    ObservacionesSalud = _producto.DatosSaludAlumno.ObservacionesSalud
                }

            };


            return View(alumnoDatosSaludModel);
        }

        [HttpPost]
        public ActionResult Eliminar(Models.AlumnoDatosSaludModel alumnoDatosSaludModel)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos= new CapaNegocio.AdministradorAlumnos();
            if (administradorAlumnos.Eliminar(alumnoDatosSaludModel.AlumnoModel.Id))
            {
                CapaNegocio.AdministradorDatosSalud administradorDatosSalud= new CapaNegocio.AdministradorDatosSalud();
                if (administradorDatosSalud.Eliminar(alumnoDatosSaludModel.DatosSaludAlumnoModel.IdSalud))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }



    }
}