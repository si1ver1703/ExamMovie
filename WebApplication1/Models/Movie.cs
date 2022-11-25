using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
        public class Movie
        {
            public int ID { get; set; } 
        
            public string Title { get; set; }

            public string Image { get; set; }

            [Display(Name = "Release Date")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
        }
}
