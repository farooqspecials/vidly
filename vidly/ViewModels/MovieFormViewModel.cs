using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormViewModel
    {
         public IEnumerable<Genre> Genres { get; set; }


         public int? Id { get; set; }

         [Required]
         [StringLength(255)]
         public string Name { get; set; }

         [Display(Name = "Genre")]
         [Required]
         public byte? GenreId { get; set; }

         [Display(Name = "Release Date")]
         [Required]
         public DateTime? ReleaseDate { get; set; }

         [Display(Name = "Number in Stock")]
         [Range(1, 20)]
         [Required]
         public byte? NumberInStock { get; set; }

        public Movies Movie { get; set; }


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movies movie)
        {
            Id = movie.id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
        

    }
}