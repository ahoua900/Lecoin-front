using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lecoin.Models
{
    public class Panier
    {
        [Key]
        public int IdPanier { get; set; }
        public string NomClient { get; set; }
        public int IdArticle { get; set; }
        public string NomArticle { get; set; }
        public string Categorie { get; set; }
        public string Description { get; set; }
        public string NomVendeur { get; set; }
        public string PhotoArticle { get; set; }
        public int SommeTotale { get; set; }
        public int Quantité { get; set; }
        public bool IsActif { get; set; }
       

    }
}