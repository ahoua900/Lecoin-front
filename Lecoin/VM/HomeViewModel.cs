using System;
using System.Collections.Generic;
using System.Linq;
using Lecoin.Models;
using System.Web;

namespace Lecoin.VM
{
    public class HomeViewModel
    {
        public List<Articles> Articles { get; set; }
        public List<Articles> AllArticles { get; set; }
        public List<Panier> Paniers { get; set; }
        public Negociation Negociation { get; set; }
        public List<Information>  Information { get; set; }
    }
}