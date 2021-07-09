using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lecoin.Models
{
    public class Categories
    {
        [Key]
        public int IdCategories { get; set; }
        public string NOmCategorie { get; set; }
        public int Nbres { get; set; }
    }
}