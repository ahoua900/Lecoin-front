using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecoin.Models
{
    public class Clients
    {
        [Key]
        public int IdClient { get; set; }
        [Required(ErrorMessage ="Entrez votre nom s'il vou plait")]
        public string Nom_client { get; set; }
        [Required(ErrorMessage = "Entrez votre Prenom s'il vou plait")]
        public string Prenom_client { get; set; }
        [Required(ErrorMessage = "Entrez votre contact s'il vou plait")]
        public string Tel_client { get; set; }
        [Required(ErrorMessage = "Entrez votre email s'il vou plait")]
        public string Email_client { get; set; }
        [Required(ErrorMessage = "Entrez votre mot de passe s'il vou plait")]
        public string MotDePasse { get; set; }
    }
}