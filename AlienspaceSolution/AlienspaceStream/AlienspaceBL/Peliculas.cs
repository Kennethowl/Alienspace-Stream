using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienspaceBL
{
   public class Peliculas
    {
       /* public Peliculas()
        {
            Activo = true;
        }*/

        public int Id { get; set; }

        [Display(Name ="Pelicula")]
        [Required(ErrorMessage = "Ingrese la pelicula")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Ingrese maximo 50 caracteres")]
        public string Pelicula { get; set; }
        public double Precio { get; set; }

        public int CategoriaId { get; set; }
        public  Categoria Categoria { get; set; }

        [Display(Name ="Imagen")]
        public string UrlImagen { get; set;  }
        //public int CategoriaId { get; set; }
        //public bool Activo { get; set; }
    }
}
