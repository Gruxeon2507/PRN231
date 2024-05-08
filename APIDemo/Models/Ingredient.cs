using System;
using System.Collections.Generic;

namespace APIDemo.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipesIngredients = new HashSet<RecipesIngredient>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Calories { get; set; }

        public virtual ICollection<RecipesIngredient> RecipesIngredients { get; set; }
    }
}
