using System;
using System.Collections.Generic;

namespace APIDemo.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            MealsRecipes = new HashSet<MealsRecipe>();
            RecipesIngredients = new HashSet<RecipesIngredient>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Images { get; set; }

        public virtual ICollection<MealsRecipe> MealsRecipes { get; set; }
        public virtual ICollection<RecipesIngredient> RecipesIngredients { get; set; }
    }
}
