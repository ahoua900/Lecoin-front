using Microsoft.EntityFrameworkCore;
using System;
using Lecoin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecoin.DAL
{
    public class LecoinContext : DbContext
    {
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Negociation>  Negociations { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Information> Informations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=winheb02.ikoula.com\MSSQLSERVER2017;Initial Catalog=inapedor_Lecoin;Persist Security Info=True;User ID=inapedor_user;Password=Maman68466745@@;TrustServerCertificate=True"));
        }
    }
}