using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchioOnlineShop.Models;

namespace WatchioOnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet <categorie> categorie { set; get; }    //migration du table categorie 

        public DbSet <article> article { set; get; }   //migration du table article

        public DbSet<commande> commande { set; get; }   //migration du table commande

        public DbSet <ApplicationUser> ApplicationUsers { set; get; }


    }
}
