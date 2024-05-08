using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIDemo.Models
{
    public partial class PRN221_MealManagementContext : DbContext
    {
        public PRN221_MealManagementContext()
        {
        }

        public PRN221_MealManagementContext(DbContextOptions<PRN221_MealManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<MealsRecipe> MealsRecipes { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipesIngredient> RecipesIngredients { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database =PRN221_MealManagement;uid=duckm;pwd=123456;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("ingredients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("meals");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("datetime")
                    .HasColumnName("createdBy");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__meals__userId__32E0915F");
            });

            modelBuilder.Entity<MealsRecipe>(entity =>
            {
                entity.ToTable("meals_recipes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MealId).HasColumnName("mealId");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.MealsRecipes)
                    .HasForeignKey(d => d.MealId)
                    .HasConstraintName("FK__meals_rec__mealI__2F10007B");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.MealsRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__meals_rec__recip__300424B4");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Images).HasColumnName("images");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RecipesIngredient>(entity =>
            {
                entity.ToTable("recipes_ingredients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipesIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK__recipes_i__ingre__31EC6D26");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipesIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__recipes_i__recip__30F848ED");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
