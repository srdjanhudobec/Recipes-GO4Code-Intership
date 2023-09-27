using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Recipes.Models;
using Recipes.Models.Ingredient;
using Recipes.Models.Users;

namespace Recipes.Data
{
    public class DatabaseContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<UserBookmark> Bookmarks { get; set; }

        public DbSet<IngredientWithQuantity> IngredientWithQuantities { get; set; }


        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<IngredientWithQuantity>().HasKey(u => u.Id);

            modelBuilder.Entity<UserBookmark>().HasKey(u => u.Id);

            //modelBuilder.Entity<UserBookmark>().HasIndex(u => u.RecipeName).IsUnique();
        }
    }
}
