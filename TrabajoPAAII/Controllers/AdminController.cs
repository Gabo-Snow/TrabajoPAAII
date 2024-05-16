using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoPAAII.Models;

namespace TrabajoPAAII.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult AdminAlumno()
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();

            var _listaAlumnos = administradorAlumnos.GetAlumnos();

            List<Models.AlumnoModel> alumnoModels = new List<AlumnoModel>();

            foreach (var a in _listaAlumnos)
            {
                alumnoModels.Add(new AlumnoModel
                {
                    Id = a.Id,
                    Rut = a.Rut,
                    Nombre = a.Nombre,
                    Apellido = a.Apellido,
                    Edad = a.Edad,
                    Sexo = a.Sexo,
                    IdSalud = a.IdSalud
                                        
                });
            }

            return View(alumnoModels);
        }

        public ActionResult AdminCarrera()
        {
            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();

            var _listaCarreras = administradorCarreras.GetCarreras();

            List<Models.CarreraModel> carreraModels = new List<CarreraModel>();

            foreach (var c in _listaCarreras)
            {
                carreraModels.Add(new CarreraModel
                {
                    Id = c.Id,
                    Codigo = c.Codigo,
                    NombreCarrera = c.NombreCarrera,
                    AreaNegocio = c.AreaNegocio,
                    Estado = c.Estado
                });

            }

            return View(carreraModels);
        }

        public  ActionResult CrearAlumno()
        {
            return View(new AlumnoModel());
        }

        public ActionResult CrearCarrera()
        {
            return View(new CarreraModel());
        }

        [HttpPost]
        public ActionResult CrearAlumno(AlumnoModel alumnoModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estado = false;
                ViewBag.MensajeError = "";
                return View(alumnoModel);
            }

            Entidades.Alumno alumno = new Entidades.Alumno
            {
                Rut = alumnoModel.Rut,
                Nombre = alumnoModel.Nombre,
                Apellido = alumnoModel.Apellido,
                Edad = alumnoModel.Edad,
                Sexo = alumnoModel.Sexo
            };

            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();

            if (administradorAlumnos.Crear(alumno))
            {
                return RedirectToAction("Inicio");
            }
            else
            {
                return View(alumnoModel);
            }
            

        }
        [HttpPost]
        public ActionResult CrearCarrera(CarreraModel carreraModel)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Estado = false;
                ViewBag.MensajeError = "";
                return View(carreraModel);
            }

            Entidades.Carrera carrera = new Entidades.Carrera
            {
                Codigo = carreraModel.Codigo,
                NombreCarrera = carreraModel.NombreCarrera,
                AreaNegocio = carreraModel.AreaNegocio,
                Estado = carreraModel.Estado
            };           


            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();
            if (administradorCarreras.Crear(carrera))
            {
                return RedirectToAction("Inicio");
            }
            else
            {
                return View(carreraModel);
            }
                     
        }

        public ActionResult EditarAlumno(int id)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();

            Entidades.Alumno _alumno = administradorAlumnos.GetAlumno(id);

            AlumnoModel alumnoModel = new AlumnoModel
            {
                Id = _alumno.Id,
                Rut = _alumno.Rut,
                Nombre = _alumno.Nombre,
                Apellido = _alumno.Apellido,
                Edad = _alumno.Edad,
                Sexo = _alumno.Sexo,
                IdSalud = _alumno.IdSalud

            };           
            return View(alumnoModel);
        }

        [HttpPost]
        public ActionResult EditarAlumno(AlumnoModel alumnoModel)
        {
            Entidades.Alumno alumno = new Entidades.Alumno
            {
                Id = alumnoModel.Id,
                Rut = alumnoModel.Rut,
                Nombre = alumnoModel.Nombre,
                Apellido = alumnoModel.Apellido,
                Edad = alumnoModel.Edad,
                Sexo = alumnoModel.Sexo,
                IdSalud = alumnoModel.IdSalud                

            };

            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();

            if (administradorAlumnos.Actualizar(alumno))
            {
                return RedirectToAction("AdminAlumno");
            }
            return View();
        }

        public ActionResult EditarCarrera(int id)
        {
            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();

            Entidades.Carrera _carreras = administradorCarreras.GetCarrera(id);

            CarreraModel carreraModel = new CarreraModel
            {
                Id = _carreras.Id,
                Codigo = _carreras.Codigo,
                NombreCarrera = _carreras.NombreCarrera,
                AreaNegocio = _carreras.AreaNegocio,
                Estado = _carreras.Estado
                
            };
            return View(carreraModel);
        }

        [HttpPost]
        public ActionResult EditarCarrera(CarreraModel carreraModel)
        {
            Entidades.Carrera carrera = new Entidades.Carrera
            {
                Id = carreraModel.Id,
                Codigo = carreraModel.Codigo,
                NombreCarrera = carreraModel.NombreCarrera,
                AreaNegocio = carreraModel.AreaNegocio,
                Estado = carreraModel.Estado
            };

            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();

            if (administradorCarreras.Actualizar(carrera))
            {
                return RedirectToAction("AdminCarrera");
            }

            return View();
        }
        [HttpGet]
        public ActionResult DetalleAlumno(int id)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();
            Entidades.Alumno _alumno = administradorAlumnos.GetAlumno(id);

            AlumnoModel alumnoModel = new AlumnoModel
            {
                Id = _alumno.Id,
                Rut = _alumno.Rut,
                Nombre = _alumno.Nombre,
                Apellido = _alumno.Apellido,
                Edad = _alumno.Edad,
                Sexo = _alumno.Sexo,
                IdSalud = _alumno.IdSalud
            };

            return View(alumnoModel);
        }

        [HttpPost]
        public ActionResult DetalleAlumno(AlumnoModel alumnoModel)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();

            if (administradorAlumnos.Eliminar(alumnoModel.Id))
            {
                return RedirectToAction("Inicio");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetalleCarrera(int id)
        {
            CapaNegocio.AdministradorCarreras administradorCarreras= new CapaNegocio.AdministradorCarreras();
            Entidades.Carrera   _carrera= administradorCarreras.GetCarrera(id);

            CarreraModel  carreraModel = new CarreraModel
            {
                Id = _carrera.Id,
                Codigo = _carrera.Codigo,
                NombreCarrera = _carrera.NombreCarrera,
                AreaNegocio = _carrera.AreaNegocio,
                Estado = _carrera.Estado
              
            };

            return View(carreraModel);
        }

        [HttpPost]
        public ActionResult DetalleCarrera(CarreraModel carreraModel)
        {
            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();

            if (administradorCarreras.Eliminar(carreraModel.Id))
            {
                return RedirectToAction("Inicio");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EliminarCarrera(int id)
        {
            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();
            Entidades.Carrera _carrera = administradorCarreras.GetCarrera(id);

            CarreraModel carreraModel = new CarreraModel
            {
                Id = _carrera.Id,
                Codigo = _carrera.Codigo,
                NombreCarrera = _carrera.NombreCarrera,
                AreaNegocio = _carrera.AreaNegocio,
                Estado = _carrera.Estado

            };

            return View(carreraModel);
        }
        [HttpPost]
        public ActionResult EliminarCarrera(CarreraModel carreraModel)
        {
            CapaNegocio.AdministradorCarreras administradorCarreraas= new CapaNegocio.AdministradorCarreras();

            if (administradorCarreraas.Eliminar(carreraModel.Id))
            {
                return RedirectToAction("Inicio");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EliminarAlumno(int id)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();
            Entidades.Alumno _alumno = administradorAlumnos.GetAlumno(id);

            AlumnoModel alumnoModel = new AlumnoModel
            {
                Id = _alumno.Id,
                Rut = _alumno.Rut,
                Nombre = _alumno.Nombre,
                Apellido = _alumno.Apellido,
                Edad = _alumno.Edad,
                Sexo = _alumno.Sexo,
                IdSalud = _alumno.IdSalud
            };

            return View(alumnoModel);
        }

        [HttpPost]
        public ActionResult EliminarAlumno(AlumnoModel alumnoModel)
        {
            CapaNegocio.AdministradorAlumnos administradorAlumnos = new CapaNegocio.AdministradorAlumnos();

            if (administradorAlumnos.Eliminar(alumnoModel.Id))
            {
                return RedirectToAction("Inicio");
            }
            return View();
        }
    }
}