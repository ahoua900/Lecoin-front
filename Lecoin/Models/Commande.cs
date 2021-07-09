using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lecoin.Models
{
    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }
        public int IdPanier { get; set; }
        public string Nomclient { get; set; }
        public string NumeroCommande { get; set; }
        public string NomVendeur { get; set; }
        public string Lieu { get; set; }
        public string Livraison { get; set; }
        public string Contact { get; set; }
        public bool IsDelivred { get; set; }
        public DateTime Date { get; set; }
    }
}