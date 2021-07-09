using System;
using System.Collections.Generic;
using Lecoin.Models;
using System.Linq;
using System.Web;

namespace Lecoin.VM
{
    public class ShopViewModel
    {
        public List<Articles> Articles { get; set; }
        public List<Categories> Categories { get; set; }
        public Articles Article { get; set; }
        public Negociation  Negociation { get; set; }
    }
}