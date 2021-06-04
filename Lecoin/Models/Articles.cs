using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lecoin.Models
{
    public class Articles
    {
        [Key]
        public int IdArticle { get; set; }
        [Required(ErrorMessage ="Entrez le nom de l'article s'il vous plait")]
        public string NomArticle { get; set; }
        [Required(ErrorMessage = "Entrez le prix de l'article s'il vous plait")]
        public string Prix { get; set; }
        [Required(ErrorMessage = "Entrez la description de l'article s'il vous plait")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Entrez le nom du vendeur de l'article s'il vous plait")]
        public string NomVendeur { get; set; }
        [Required(ErrorMessage = "Entrez la photo de l'article s'il vous plait")]
        public string PhotoArticle { get; set; }
        [Required(ErrorMessage = "Entrez la quantité disponible de l'article s'il vous plait")]
        public int QuantitéDispo { get; set; }
    }
}