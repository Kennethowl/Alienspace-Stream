using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlienspaceAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _CategoriasBL;

        public CategoriasController()
        {
            _CategoriasBL = new CategoriasBL();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _CategoriasBL.ObtenerCategorias();

            return View(listadeCategorias);
        }

        //[HttpGet]
        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Pelicula != categoria.Pelicula.Trim())
                {
                    ModelState.AddModelError("Pelicula", "El nombre de la pelicula no debe contener espacios al inicio ni al final");
                    return View(categoria);
                }
                _CategoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Edit(int id)
        {
            var peliculas = _CategoriasBL.ObtenerCategorias(id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Pelicula != categoria.Pelicula.Trim())
                {
                    ModelState.AddModelError("Pelicula", "El nombre de la pelicula no debe contener espacios al inicio ni al final");
                    return View(categoria);
                }
                _CategoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Details(int id)
        {
            var peliculas = _CategoriasBL.ObtenerCategorias(id);

            return View(peliculas);
        }

        public ActionResult Delete(int id)
        {
            var peliculas = _CategoriasBL.ObtenerCategorias(id);

            return View(peliculas);
        }

        [HttpPost]
        public ActionResult Delete(Categoria peliculas)
        {
            _CategoriasBL.EliminarCategorias(peliculas.Id);

            return RedirectToAction("Index");
        }
    }
}