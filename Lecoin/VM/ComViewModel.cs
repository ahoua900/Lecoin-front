using System;
using System.Collections.Generic;
using Lecoin.Models;
using System.Linq;
using System.Web;

namespace Lecoin.VM
{
    public class ComViewModel
    {
        public List<Commande> CommandeRecues { get; set; }
        public List<Commande> CommandeEnvoye { get; set; }
        public Clients Clients { get; set; }
        public List<Panier> Paniers { get; set; }
        public List<Articles> Articles { get; set; }
        public Articles Article { get; set; }
    }
}