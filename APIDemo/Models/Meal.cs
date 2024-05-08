using System;
using System.Collections.Generic;

namespace APIDemo.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealsRecipes = new HashSet<MealsRecipe>();
        }

        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime? CreatedBy { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<MealsRecipe> MealsRecipes { get; set; }
    }
}
