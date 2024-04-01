using System;
using System.Collections.Generic;

namespace CookBook_Application_Exam.Models
{
    public class Cuisine
    {

        public string Name { get; set; } = string.Empty;
        public List<Recipe> Recipes { get; set; } = [];
        public override bool Equals(object? obj)
        {
            return Name == (obj as Cuisine)?.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

}
