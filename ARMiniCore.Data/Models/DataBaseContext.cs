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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPase>().HasOne(u => u.Usuario)
                .WithMany(u => u.UsuarioPases)
                .HasForeignKey(u => u.UsuarioId);

            modelBuilder.Entity<UsuarioPase>().HasOne(u => u.Pase)
                .WithMany(u => u.UsuarioPases)
                .HasForeignKey(u => u.PaseId);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pase> Pase { get; set; }
        public DbSet<UsuarioPase> UsuarioPase { get; set; }
    }
}
