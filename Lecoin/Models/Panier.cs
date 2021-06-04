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
        public List<Articles> Articles { get; set; }
        public int SommeTotale { get; set; }
        public int NbreArticles { get; set; }
    }
}