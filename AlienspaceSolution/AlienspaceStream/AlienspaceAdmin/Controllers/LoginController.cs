using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlienspaceAdmin.Controllers
{
    public class LoginController : Controller
    {
        SeguridadBl _seguridadBl;

        public LoginController()
        {
            _seguridadBl = new SeguridadBl();
        }

        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {

            var nombreUsuario = data["username"];
            var contrasena = data["password"];

            var usuarioValido = _seguridadBl.Autorizar(nombreUsuario, contrasena);

            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);
                return RedirectToAction("Index", "Home"); //pendiente
            }

            ModelState.AddModelError("", "Usuario o contraseña invalido");

            return View();
        }
    }
}