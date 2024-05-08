using System;
using System.Collections.Generic;

namespace APIDemo.Models
{
    public partial class MealsRecipe
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public int? MealId { get; set; }

        public virtual Meal? Meal { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
