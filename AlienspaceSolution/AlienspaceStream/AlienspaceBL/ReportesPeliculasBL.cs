using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienspaceBL
{
    public class ReportesPeliculasBL
    {
        Contexto _contexto;
        public List<ReportesPeliculas> ListaReportesPeliculas { get; set; }

        public ReportesPeliculasBL()
        {
            _contexto = new Contexto();
            ListaReportesPeliculas = new List<ReportesPeliculas>();
        }

        public List<ReportesPeliculas> ObtenerReportesPeliculas()
        {
            ListaReportesPeliculas = _contexto.OrdenDetalle
                .Include("Peliculas")
                .Where(p => p.Orden.Activo)
                .GroupBy(p => p.Peliculas.Pelicula)
                .Select(s => new ReportesPeliculas()
                {
                    Pelicula = s.Key,
                    Total = s.Sum(t => t.Total)

                }).ToList();
            return ListaReportesPeliculas;
        }
    }
}
