using Microsoft.EntityFrameworkCore;
using LoginDe.Net.Models;

namespace LoginDe.Net.Data
{
    public class AppDBContext : DbContext
    {
        
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.IdUsuario);
                tb.Property(col => col.IdUsuario)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre_Usuario).HasMaxLength(250);
                tb.Property(col => col.Password).HasMaxLength(250);
                tb.Property(col => col.Nombre).HasMaxLength(250);
                tb.Property(col => col.Apellido_Paterno).HasMaxLength(250);
                tb.Property(col => col.Apellido_Materno).HasMaxLength(250);
                tb.Property(col => col.Correo).HasMaxLength(250);
            });

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}
