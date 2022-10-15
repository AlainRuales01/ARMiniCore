using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMiniCore.Data.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pase> Pase { get; set; }
        public DbSet<UsuarioPase> UsuarioPase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Pase>().ToTable("Pase");
            modelBuilder.Entity<UsuarioPase>().ToTable("UsuarioPase");
        }
    }
}
