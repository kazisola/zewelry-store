using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZewelryStore.Models;

namespace ZewelryStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Add database tables
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Defining composite key and relationship for the productingredient
            builder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(pi => pi.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(pi => pi.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);
        }
    }
}
