using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alienspace_stream.Controllers
{
    public class MisPeliculasController : Controller
    {
        // GET: MisPeliculas
        public ActionResult Index()
        {
            var peliculasBL = new PeliculasBL();

            var ListaPeliculas = peliculasBL.ObtenerPeliculas();

            return View(ListaPeliculas);
        }
    }
}