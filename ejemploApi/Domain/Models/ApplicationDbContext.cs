using ejemploApi.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ejemploApi.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public void ConfigureConnection(string connectionString)
        {
            _connectionString = connectionString;
            Database.GetDbConnection().ConnectionString = _connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            else
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Compras__3214EC0725AB8B7E");

                entity.Property(e => e.FechaCompra).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Compras).HasConstraintName("FK_Compras_Usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07DECB017F");

                entity.Property(e => e.Activo).HasDefaultValue(true);
            });

        }
    }
}
