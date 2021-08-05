using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlienspaceAdmin.Controllers
{
    [Authorize]
    public class OrdenDetalleController : Controller
    {
        OrdenesBL _ordenesBL;
        PeliculasBL _peliculaBL;
        

        public OrdenDetalleController()
        {
            _ordenesBL = new OrdenesBL();
            _peliculaBL = new PeliculasBL();
            
        }

        // GET: OrdenesDetalle
        public ActionResult Index(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            //orden.ListadeOrdenDetalle = _ordenesBL.ObtenerOrdenDetalle(id);

            return View(orden);
        }

        public ActionResult Crear(int id)
        {
            var nuevaOrdenDetalle = new OrdenDetalle();
            nuevaOrdenDetalle.OrdenId = id;

            var peliculas = _peliculaBL.ObtenerPeliculas();
            ViewBag.PeliculaId = new SelectList(peliculas, "Id", "Pelicula");

            return View(nuevaOrdenDetalle);
        }

        [HttpPost]
        public ActionResult Crear(OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                if (ordenDetalle.PeliculaId == 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View(ordenDetalle);
                }

                _ordenesBL.GuardarOrdenDetalle(ordenDetalle);
                return RedirectToAction("Index", new { id = ordenDetalle.OrdenId });
            }

            var peliculas = _peliculaBL.ObtenerPeliculas();
            ViewBag.PeliculaId = new SelectList(peliculas, "Id", "Pelicula");

            return View(ordenDetalle);
        }

        public ActionResult Eliminar(int id)
        {
            var ordenDetalle = _ordenesBL.ObtenerOrdenDetallePorId(id);

            return View(ordenDetalle);
        }

        [HttpPost]
        public ActionResult Eliminar(OrdenDetalle ordenDetalle)
        {
            _ordenesBL.EliminarOrdenDetalle(ordenDetalle.Id);

            return RedirectToAction("Index", new { id = ordenDetalle.OrdenId });
        }

    }
}