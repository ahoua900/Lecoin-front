using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecoin.Models
{
    public class Information
    {
        [Key]
        public int IdInfo { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Entrez le nom du vendeur de l'article s'il vous plait")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Entrez la photo de l'article s'il vous plait")]
        [StringLength(10)]
        public string Contact { get; set; }
    }
}