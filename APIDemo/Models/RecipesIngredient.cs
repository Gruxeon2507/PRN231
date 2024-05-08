using System;
using System.Collections.Generic;

namespace APIDemo.Models
{
    public partial class RecipesIngredient
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public int? IngredientId { get; set; }
        public int? Amount { get; set; }

        public virtual Ingredient? Ingredient { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
