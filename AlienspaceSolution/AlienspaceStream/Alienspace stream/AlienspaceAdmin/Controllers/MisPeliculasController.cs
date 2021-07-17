using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlienspaceAdmin.Controllers
{
    public class MisPeliculasController : Controller
    {

        PeliculasBL _PeliculasBL;
        CategoriasBL _CategoriasBL;

        public MisPeliculasController()
        {
            _PeliculasBL = new PeliculasBL();
            _CategoriasBL = new CategoriasBL();
        }
        // GET: MisPeliculas
        public ActionResult Index()
        {
            var ListadePeliculas = _PeliculasBL.ObtenerPeliculas();

            return View(ListadePeliculas);
        }

        //[HttpGet]
        public ActionResult Crear()
        { 
            var nuevaPelicula = new Peliculas();
            var categorias = _CategoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(categorias, "Id", "Pelicula");
            return View(nuevaPelicula);
        }

        [HttpPost]
        public ActionResult Crear(Peliculas peliculas, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (peliculas.Id == 0)
                {
                    ModelState.AddModelError("Id", "Seleccione una categoria");
                    return View(peliculas);
                }

                if (imagen != null)
                {
                    peliculas.UrlImagen = GuardarImagen(imagen);
                }

                _PeliculasBL.GuardarPeliculas(peliculas);

                return RedirectToAction("Index");
            }

            var categorias = _CategoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(categorias, "Id", "Pelicula");

            return View(peliculas);
        }

        public ActionResult Edit(int id)
        {
            var peliculas = _PeliculasBL.ObtenerPeliculas(id);
            // var categorias = _CategoriasBL.ObtenerCategorias();

            // ViewBag.CategoriaId = new SelectList(categorias, "Id", "Pelicula", peliculas.CategoriaId);

            return View(peliculas);
        }

        [HttpPost]
        public ActionResult Edit(Peliculas peliculas, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (peliculas.Id == 0)
                {
                    ModelState.AddModelError("Id", "Seleccione una categoria");
                    return View(peliculas);
                }

                if (imagen != null)
                {
                    peliculas.UrlImagen = GuardarImagen(imagen);
                }

                _PeliculasBL.GuardarPeliculas(peliculas);

                return RedirectToAction("Index");
            }

            var categorias = _CategoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(categorias, "Id", "Pelicula");

            return View(peliculas);
        }

        public ActionResult Details(int id)
        {
            var peliculas = _PeliculasBL.ObtenerPeliculas(id);

            return View(peliculas);
        }

        public ActionResult Delete(int id)
        {
            var peliculas = _PeliculasBL.ObtenerPeliculas(id);

            return View(peliculas);
        }

        [HttpPost]
        public ActionResult Delete(Peliculas peliculas)
        {
            _PeliculasBL.EliminarPeliculas(peliculas.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;

        }
    }
}