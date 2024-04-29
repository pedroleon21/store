using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { 

        }

        public virtual DbSet<Usuario> Users { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.HasDefaultSchema("store");
            
            modelBuilder.Entity<Usuario>().ToTable("usuario")
                .HasMany<Loja>(u=>u.Lojas)
                .WithOne(l=>l.Usuario)
                .HasForeignKey(u=>u.Id);

            modelBuilder.Entity<Loja>().ToTable("loja")
            .HasOne<Usuario>(l => l.Usuario);
            
            modelBuilder.Entity<Loja>()
                .HasMany<Produto>(l => l.produtos)
                .WithOne(p=>p.Loja);


            modelBuilder.Entity<Produto>().ToTable("produto")
                .Property(p=>p.Preco)
                .HasPrecision(18,2)
                .HasColumnType("decimal")
                .HasColumnName("Preco");
            modelBuilder.Entity<Produto>()
                .HasOne<Loja>(p=>p.Loja);
        }
    }
}
