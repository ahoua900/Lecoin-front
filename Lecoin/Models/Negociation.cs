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
        public int IdArticle { get; set; }
        public string NomClient { get; set; }
        public string NomArticle { get; set; }
        public string NomVendeur { get; set; }
        public int Quantité { get; set; }
        public int PrixPropose { get; set; }
        public int PrixNormal { get; set; }
        public bool Issuccess { get; set; }
        public DateTime Date { get; set; }

    }
}