using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienspaceBL
{
    public class ClientesBL
    {
        Contexto _contexto;
        public List<Cliente> ListadeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new List<Cliente>();
        }

        public List<Cliente> ObtenerClientes()
        {
            ListadeClientes = _contexto.Cliente
                .OrderBy(c => c.Nombre)
                .ToList();

            //ListadePeliculas = contexto_global.Peliculas.Include("Categoria").ToList();
            return ListadeClientes; //ListaPeliculas;
        }

        public List<Cliente> ObtenerClientesActivos()
        {
            ListadeClientes = _contexto.Cliente
                .Where(c => c.Activo == true)
                .OrderBy(c => c.Nombre)
                .ToList();

            //ListadePeliculas = contexto_global.Peliculas.Include("Categoria").ToList();
            return ListadeClientes; //ListaPeliculas;
        }

        public void GuardarClientes(Cliente clientes)
        {
            if (clientes.Id == 0)
            {
                _contexto.Cliente.Add(clientes);
            }
            else
            {
                var clientesExistentes = _contexto.Cliente.Find(clientes.Id);
                clientesExistentes.Nombre = clientes.Nombre;
                clientesExistentes.Telefono = clientes.Telefono;
                clientesExistentes.Direccion = clientes.Direccion;
                clientesExistentes.Activo = clientes.Activo;
            }

            //contexto_global.Peliculas.Add(peliculas);
            _contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(int id)
        {
            var cliente = _contexto.Cliente.Find(id);

            return cliente;
        }

        public void EliminarClientes(int id)
        {
            var cliente = _contexto.Cliente.Find(id);

            _contexto.Cliente.Remove(cliente);
            _contexto.SaveChanges();
        }
    }
}
