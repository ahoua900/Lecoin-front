using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecoin.Models
{
    public class Negociation
    {
        [Key]
        public int IdNegociation { get; set; }
        public string NomArticle { get; set; }
        [Required(ErrorMessage = "Entrez le prix de l'article s'il vous plait")]
        public string Prix { get; set; }
        [Required(ErrorMessage = "Entrez votre proposition s'il vous plait")]
        public string PrixPropose { get; set; }
        [Required(ErrorMessage = "Entrez la photo de l'article s'il vous plait")]
        public string PhotoArticle { get; set; }
    }
}