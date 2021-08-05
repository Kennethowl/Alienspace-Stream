using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlienspaceAdmin.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        ClientesBL _clientesBL;

        public ClienteController()
        {
            _clientesBL = new ClientesBL();
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clientesBL.ObtenerClientes();

            return View(listadeClientes);
        }

        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();

            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarClientes(cliente);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarClientes(cliente);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Details(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            _clientesBL.EliminarClientes(cliente.Id);

            return RedirectToAction("Index");
        }
    }
}
