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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Defining composite key and relationship for the productingredient
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(pi => pi.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(pi => pi.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);



            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Rings" },
                new Category { CategoryId = 2, Name = "Necklaces" },
                new Category { CategoryId = 3, Name = "Bracelets" },
                new Category { CategoryId = 4, Name = "Earrings" },
                new Category { CategoryId = 5, Name = "Watches" }
            );

            // Seed Ingredients (Materials)
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "18K Gold" },
                new Ingredient { IngredientId = 2, Name = "Sterling Silver" },
                new Ingredient { IngredientId = 3, Name = "Diamond" },
                new Ingredient { IngredientId = 4, Name = "Pearl" },
                new Ingredient { IngredientId = 5, Name = "Ruby" },
                new Ingredient { IngredientId = 6, Name = "Sapphire" },
                new Ingredient { IngredientId = 7, Name = "Platinum" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Classic Gold Engagement Ring",
                    Description = "Elegant 18K gold engagement ring featuring a brilliant-cut diamond.",
                    Price = 1299.99m,
                    Stock = 15,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Sterling Silver Pearl Necklace",
                    Description = "Beautiful sterling silver necklace featuring a lustrous freshwater pearl.",
                    Price = 249.99m,
                    Stock = 25,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Diamond Tennis Bracelet",
                    Description = "Luxurious bracelet featuring sparkling diamonds set in 18K gold.",
                    Price = 1899.99m,
                    Stock = 8,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Ruby Stud Earrings",
                    Description = "Classic stud earrings featuring vibrant natural rubies.",
                    Price = 499.99m,
                    Stock = 20,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Sapphire Gold Pendant",
                    Description = "Elegant 18K gold pendant featuring a stunning blue sapphire.",
                    Price = 799.99m,
                    Stock = 12,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Silver Chain Bracelet",
                    Description = "Minimalist sterling silver chain bracelet suitable for everyday wear.",
                    Price = 89.99m,
                    Stock = 40,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Diamond Halo Earrings",
                    Description = "Beautiful diamond halo earrings crafted with premium platinum.",
                    Price = 1499.99m,
                    Stock = 10,
                    CategoryId = 4
                }
            );

            // Seed Product Ingredients
            modelBuilder.Entity<ProductIngredient>().HasData(
                // Classic Gold Engagement Ring
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 3 },

                // Sterling Silver Pearl Necklace
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },

                // Diamond Tennis Bracelet
                new ProductIngredient { ProductId = 3, IngredientId = 1 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },

                // Ruby Stud Earrings
                new ProductIngredient { ProductId = 4, IngredientId = 5 },

                // Sapphire Gold Pendant
                new ProductIngredient { ProductId = 5, IngredientId = 1 },
                new ProductIngredient { ProductId = 5, IngredientId = 6 },

                // Silver Chain Bracelet
                new ProductIngredient { ProductId = 6, IngredientId = 2 },

                // Diamond Halo Earrings
                new ProductIngredient { ProductId = 7, IngredientId = 7 },
                new ProductIngredient { ProductId = 7, IngredientId = 3 }
            );
        }
    }
}
