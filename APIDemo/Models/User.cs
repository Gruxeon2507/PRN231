using System;
using System.Collections.Generic;

namespace APIDemo.Models
{
    public partial class User
    {
        public User()
        {
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
