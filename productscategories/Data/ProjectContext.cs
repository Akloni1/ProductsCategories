using Microsoft.EntityFrameworkCore;
using productscategories.Models;

namespace productscategories.Data
{
    public partial class ProjectContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ProjectContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCategories> ProductsCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProjectContext"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<ProductsCategories>(entity =>
            {
                entity.HasKey(e => new { e.IdCategory, e.IdProduct });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsCategories)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsCategories_Product");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductsCategories)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsCategories_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
