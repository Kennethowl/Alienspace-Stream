using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alienspace_stream.Controllers
{
    public class HomeController : Controller
    {
        // GET: AlienspaceStream
        public ActionResult Index()
        {
            var peliculasBL = new PeliculasBL();
            var listaPeliculas = peliculasBL.ObtenerPeliculas();

            ViewBag.adminWebSiteUrl = ConfigurationManager.AppSettings["adminWebSiteUrl"];

            return View(listaPeliculas);     
        }
    }
}