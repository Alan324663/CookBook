using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CookBook_Application_Exam.Models
{
    public class Recipe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore] public Cuisine Cuisine { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Images { get; set; }
        public string Type { get; set; }
        public List<string> Steps { get; set; }

        // Constructor to initialize properties
        public Recipe()
        {
            Title = string.Empty;
            Description = string.Empty;
            Cuisine = new Cuisine();
            Ingredients = new List<string>();
            Images = new List<string>();
            Type = string.Empty;
            Steps = new List<string>();
        }

        // Computed property to get Ingredients as a comma-separated string
        public string IngredientsAsString => string.Join(", ", Ingredients);

        // Computed property to get Steps as a newline-separated string
        public string StepsAsString => string.Join(Environment.NewLine, Steps);
    }
}
