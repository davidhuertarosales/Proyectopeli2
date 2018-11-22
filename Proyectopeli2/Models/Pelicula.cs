using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Proyectopeli2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyectopeli2.Models
{
    public class Pelicula
    {
        //PhotoID. This is the primary key
        [Key]
        public int PeliID { get; set; }
        //Title. The title of the photo
        [Required]
        public string Title { get; set; }
        //Poster1
        [DisplayName("Poster")]
        [Column(TypeName ="Varchar(MAX)")]
        public String Poster { get; set; }
        //Poster2
        [DisplayName("Poster2")]
        [Column(TypeName = "Varchar(MAX)")]
        public String Poster2 { get; set; }
        //video
        [DisplayName("Triller")]
        [Column(TypeName = "Varchar(MAX)")]
        public String Video { get; set; }
        //Description.
        [Required]
        [DataType(DataType.MultilineText)]
        public string Sinopsis { get; set; }
        //CreatedDate
        [Required]
        [Display(Name = "Fecha de lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_estreno { get; set; }
        //Duracion 
        [Required]
        [Display(Name = "Duracion")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Duracion { get; set; }
        //Generos
        [Required]
        [DisplayName("Generos")]
        public string Generos { get; set; }
        //Idiomas
        [Required]
        [DisplayName("Idioma original")]
        public string Idiomas { get; set; }
        //UserName. This is the name of the user who created the photo
        [Required]
        public string Director { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }

    }
   
}