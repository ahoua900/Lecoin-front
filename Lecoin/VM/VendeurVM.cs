using System;
using System.Collections.Generic;
using Lecoin.Models;
using System.Linq;
using System.Web;

namespace Lecoin.VM
{
    public class VendeurVM
    {
        public List<Articles> Articles { get; set; }
        public Clients Clients { get; set; }
    }
}