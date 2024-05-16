using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using TrabajoPAAII.Models;

namespace TrabajoPAAII.Controllers
{
    public class AdminAsignaturaController : Controller
    {
        // GET: AdminAsignatura
        public ActionResult Index()
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new CapaNegocio.AdministradorAsignatura();
            var asignaturaConCarrera = administradorAsignatura.GetaAsignaturasConCarreras();

            List<Models.AsignaturaCarreraModel> listaAsignaturaCarrera = new List<Models.AsignaturaCarreraModel>();

            foreach (var a in asignaturaConCarrera)
            {
                listaAsignaturaCarrera.Add(new Models.AsignaturaCarreraModel
                {

                    AsignaturaModel = new Models.AsignaturaModel
                    {
                        IdAsignatura = a.Asignatura.IdAsignatura,
                        Asignatura1 = a.Asignatura.Asignatura1,
                        IdCarrera = a.Asignatura.IdCarrera,
                        Semestre = a.Asignatura.Semestre

                    },
                    CarreraModel = new Models.CarreraModel
                    {
                        Id = a.Carrera.Id,
                        Codigo = a.Carrera.Codigo,
                        NombreCarrera = a.Carrera.NombreCarrera,
                        AreaNegocio = a.Carrera.AreaNegocio,
                        Estado = a.Carrera.Estado
                    }
                });

            }

            return View(listaAsignaturaCarrera);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            #region DropdownList
            var listaCarreras = GetCarreras();

            List<SelectListItem> selectListItems = listaCarreras.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.NombreCarrera,
                    Value = l.Id.ToString()
                };
            });

            ViewBag.ListaCarreras = selectListItems;
            #endregion
            return View(new Models.AsignaturaCarreraModel());

        }

        [HttpPost]
        public ActionResult Crear(Models.AsignaturaCarreraModel model)
        {
            Entidades.AsignaturaCarrera asignaturaCarrera = new Entidades.AsignaturaCarrera
            {
                Asignatura = new Entidades.Asignatura
                {
                    Asignatura1 = model.AsignaturaModel.Asignatura1,
                    Semestre = model.AsignaturaModel.Semestre,
                    IdCarrera = model.AsignaturaModel.IdCarrera
                },
                Carrera = new Entidades.Carrera
                {
                    Codigo = model.CarreraModel.Codigo,
                    AreaNegocio = model.CarreraModel.AreaNegocio,
                    Estado = model.CarreraModel.Estado,
                    NombreCarrera = model.CarreraModel.NombreCarrera,
                }
            };

            CapaNegocio.AdministradorAsignatura administradorAsignatura = new AdministradorAsignatura();
            if (administradorAsignatura.Crear(asignaturaCarrera))
            {
                return RedirectToAction("Index");
            }
            #region DropdownList

            var listaCarreras = GetCarreras();

            List<SelectListItem> selectListItems = listaCarreras.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.NombreCarrera,
                    Value = l.Id.ToString()
                };
            });

            ViewBag.ListaCarreras = selectListItems;

            #endregion

            return View(model);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new CapaNegocio.AdministradorAsignatura();

            var _asignatura = administradorAsignatura.GetAsignaturaId(id);

            Models.AsignaturaCarreraModel asignaturaCarreraModel = new Models.AsignaturaCarreraModel
            {
                AsignaturaModel = new Models.AsignaturaModel
                {
                    IdAsignatura = _asignatura.Asignatura.IdAsignatura,
                    Asignatura1 = _asignatura.Asignatura.Asignatura1,
                    IdCarrera = _asignatura.Asignatura.IdCarrera,
                    Semestre = _asignatura.Asignatura.Semestre
                },
                CarreraModel = new Models.CarreraModel
                {
                    Id = _asignatura.Carrera.Id,
                    Codigo = _asignatura.Carrera.Codigo,
                    NombreCarrera = _asignatura.Carrera.NombreCarrera,
                    AreaNegocio = _asignatura.Carrera.AreaNegocio,
                    Estado = _asignatura.Carrera.Estado
                }
            };

            #region dropdown list
            var listaCarreras = GetCarreras();

            List<SelectListItem> selectListItems = listaCarreras.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.NombreCarrera,
                    Value = l.Id.ToString(),
                    Selected = l.Id == asignaturaCarreraModel.AsignaturaModel.IdCarrera ? true : false
                };
            });
            ViewBag.ListaCarreras = selectListItems;

            #endregion

            return View(asignaturaCarreraModel);
        }


        [HttpPost]
        public ActionResult Editar(Models.AsignaturaCarreraModel model)
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new CapaNegocio.AdministradorAsignatura();
            bool result = administradorAsignatura.ActualizarAsignatura(new Entidades.AsignaturaCarrera
            {
                Asignatura = new Entidades.Asignatura
                {
                    IdAsignatura = model.AsignaturaModel.IdAsignatura,
                    Asignatura1 = model.AsignaturaModel.Asignatura1,
                    Semestre = model.AsignaturaModel.Semestre,
                    IdCarrera = model.AsignaturaModel.IdCarrera
                },
                Carrera = new Entidades.Carrera
                {
                    Id = model.CarreraModel.Id,
                    Codigo = model.CarreraModel.Codigo,
                    NombreCarrera = model.CarreraModel.NombreCarrera,
                    AreaNegocio = model.CarreraModel.AreaNegocio,
                    Estado = model.CarreraModel.Estado

                }

            });

            if (result)
            {
                return RedirectToAction("Index");
            }

            var _asignatura = administradorAsignatura.GetAsignaturaId(model.AsignaturaModel.IdAsignatura);

            Models.AsignaturaCarreraModel asignaturaCarreraModel = new Models.AsignaturaCarreraModel
            {
                AsignaturaModel = new Models.AsignaturaModel
                {
                    IdAsignatura = _asignatura.Asignatura.IdAsignatura,
                    Asignatura1 = _asignatura.Asignatura.Asignatura1,
                    Semestre = _asignatura.Asignatura.Semestre,
                    IdCarrera = _asignatura.Asignatura.IdCarrera
                },
                CarreraModel = new Models.CarreraModel
                {
                    Id = _asignatura.Carrera.Id,
                    Codigo = _asignatura.Carrera.Codigo,
                    NombreCarrera = _asignatura.Carrera.NombreCarrera,
                    AreaNegocio = _asignatura.Carrera.AreaNegocio,
                    Estado = _asignatura.Carrera.Estado
                }
            };

            #region dropdownlist    

            var listadoCarreras = GetCarreras();

            List<SelectListItem> selectListItems = listadoCarreras.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.NombreCarrera,
                    Value = l.Id.ToString(),
                    Selected = l.Id == asignaturaCarreraModel.AsignaturaModel.IdCarrera ? true : false
                };
            });

            ViewBag.ListaCarreras = selectListItems;

            #endregion

            return View(asignaturaCarreraModel);

        }

        public List<Models.AsignaturaModel> GetAsignatura()
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new CapaNegocio.AdministradorAsignatura();
            var _ = administradorAsignatura.GetAsignaturas();

            List<Models.AsignaturaModel> asignaturaModels = new List<Models.AsignaturaModel>();

            foreach (var a in _)
            {
                asignaturaModels.Add(new Models.AsignaturaModel
                {
                    IdAsignatura = a.IdAsignatura,
                    Asignatura1 = a.Asignatura1,
                    Semestre = a.Semestre
                });
            }
            return asignaturaModels;
        }

        public List<Models.CarreraModel> GetCarreras()
        {
            CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();
            var _ = administradorCarreras.GetCarreras();

            List<Models.CarreraModel> carreraModels = new List<Models.CarreraModel>();

            foreach (var c in _)
            {
                carreraModels.Add(new Models.CarreraModel
                {
                    Id = c.Id,
                    Codigo = c.Codigo,
                    NombreCarrera = c.NombreCarrera,
                    AreaNegocio = c.AreaNegocio,
                    Estado = c.Estado
                });
            }

            return carreraModels;
        }


        [HttpGet]
        public ActionResult Detalle(int id)
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new CapaNegocio.AdministradorAsignatura();

            var _asignatura = administradorAsignatura.GetAsignaturaId(id);

            Models.AsignaturaCarreraModel asignaturaCarreraModel = new Models.AsignaturaCarreraModel
            {
                AsignaturaModel = new Models.AsignaturaModel
                {
                    IdAsignatura = _asignatura.Asignatura.IdAsignatura,
                    Asignatura1 = _asignatura.Asignatura.Asignatura1,
                    IdCarrera = _asignatura.Asignatura.IdCarrera,
                    Semestre = _asignatura.Asignatura.Semestre
                },
                CarreraModel = new Models.CarreraModel
                {
                    Id = _asignatura.Carrera.Id,
                    Codigo = _asignatura.Carrera.Codigo,
                    NombreCarrera = _asignatura.Carrera.NombreCarrera,
                    AreaNegocio = _asignatura.Carrera.AreaNegocio,
                    Estado = _asignatura.Carrera.Estado
                }
            };

            return View(asignaturaCarreraModel);
        }

        [HttpPost]
        public ActionResult Detalle(AsignaturaCarreraModel asignaturaCarreraModel)
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new AdministradorAsignatura();
            if (administradorAsignatura.Eliminar(asignaturaCarreraModel.AsignaturaModel.IdAsignatura))
            {
                CapaNegocio.AdministradorCarreras administradorCarreras = new CapaNegocio.AdministradorCarreras();
                if (administradorCarreras.Eliminar(asignaturaCarreraModel.CarreraModel.Id))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new AdministradorAsignatura();

            Entidades.AsignaturaCarrera _asignaturaCarrera = administradorAsignatura.GetAsignaturaId(id);

            AsignaturaCarreraModel asignaturaCarreraModel = new AsignaturaCarreraModel
            {
                AsignaturaModel = new AsignaturaModel
                {
                    IdAsignatura = _asignaturaCarrera.Asignatura.IdAsignatura,
                    Asignatura1 = _asignaturaCarrera.Asignatura.Asignatura1,                    
                    IdCarrera = _asignaturaCarrera.Asignatura.IdCarrera,
                    Semestre = _asignaturaCarrera.Asignatura.Semestre
                },
                CarreraModel = new CarreraModel
                {
                    Id = _asignaturaCarrera.Carrera.Id,
                    AreaNegocio = _asignaturaCarrera.Carrera.AreaNegocio,
                    Codigo = _asignaturaCarrera.Carrera.Codigo,
                    Estado = _asignaturaCarrera.Carrera.Estado,                    
                    NombreCarrera = _asignaturaCarrera.Carrera.NombreCarrera
                }
            };

            return View(asignaturaCarreraModel);
        }


        [HttpPost]
        public ActionResult Eliminar(Models.AsignaturaCarreraModel asignaturaCarreraModel)
        {
            CapaNegocio.AdministradorAsignatura administradorAsignatura = new CapaNegocio.AdministradorAsignatura();
            if (administradorAsignatura.Eliminar(asignaturaCarreraModel.AsignaturaModel.IdAsignatura))
            {
                CapaNegocio.AdministradorCarreras administradorCarreras = new AdministradorCarreras();
                if (administradorCarreras.Eliminar(asignaturaCarreraModel.CarreraModel.Id))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
