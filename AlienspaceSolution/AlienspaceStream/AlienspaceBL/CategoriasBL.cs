using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienspaceBL
{
    public class CategoriasBL
    {
        Contexto contexto_global;
        public List<Categoria> ListadeCategorias { get; set; }

        public CategoriasBL()
        {
            contexto_global = new Contexto();
            ListadeCategorias = new List<Categoria>();
        }


        public List<Categoria> ObtenerCategorias()
        {
            // contexto_global.Peliculas.ToList();

            ListadeCategorias = contexto_global.Categorias
                .OrderBy(c => c.Pelicula)
                .ToList();

            return ListadeCategorias; //ListaPeliculas;
        }

        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                contexto_global.Categorias.Add(categoria);
            }
            else
            {
                var categoriasExistentes = contexto_global.Categorias.Find(categoria.Id);
                categoriasExistentes.Pelicula = categoria.Pelicula;
            }

            //contexto_global.Peliculas.Add(peliculas);
            contexto_global.SaveChanges();
        }

        public Categoria ObtenerCategorias(int id)
        {
            var categoria = contexto_global.Categorias.Find(id);

            return categoria;
        }

        public void EliminarCategorias(int id)
        {
            var categoria = contexto_global.Categorias.Find(id);

            contexto_global.Categorias.Remove(categoria);
            contexto_global.SaveChanges();
        }
    }
}
