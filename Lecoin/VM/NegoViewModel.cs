using System;
using System.Collections.Generic;
using System.Linq;
using Lecoin.Models;
using System.Web;

namespace Lecoin.VM
{
    public class NegoViewModel
    {
        public List<Negociation> NegociationsRecues { get; set; }
        public List<Negociation> NegociationsEnvoye { get; set; }
        public Panier Panier { get; set; }
        public Commande Commande { get; set; }
        public Clients Client { get; set; }
    }
}