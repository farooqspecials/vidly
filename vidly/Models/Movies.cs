using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Movies
    {
        public int id { get; set; }
        
        [Required]
       [StringLength(255)]
        public string Name { get; set; }

        
       public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

         public DateTime ReleaseDate { get; set; }
         [Display(Name = "Number in Stock")] 
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}