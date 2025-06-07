using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicShopApp.Form1;

namespace MusicShopApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<IKeyboard> Keyboards { get; set; }
        public DbSet<Stringed> Stringeds { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MusicShop;Username=postgres;Password=210705jim37#");
        }
    }
}
