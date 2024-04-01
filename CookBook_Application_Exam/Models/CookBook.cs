using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace CookBook_Application_Exam.Models
{
    public class CookBook
    {
        private readonly string filePath = "MyData.json";
        private const string FilePath = "MyData.json";

        public Cuisine SelectedCuisine { get; set; }
        public string Name { get; set; } = "STEP Academy";
        public List<Cuisine> Cuisines { get; set; }
        public List<Recipe> AllRecipes { get; set; } // List of all recipes

        public CookBook()
        {
            filePath = FilePath;
            Cuisines = new List<Cuisine>();
            AllRecipes = new List<Recipe>();
            Load();
        }

        // Add a new recipe to a cuisine
        public void AddRecipe(Recipe recipe, Cuisine cuisine)
        {
            if (cuisine != null && recipe != null)
            {
                cuisine.Recipes.Add(recipe); // Add the recipe to the cuisine
                recipe.Cuisine = cuisine;
                SaveToFile(); // Save after adding a recipe
                Load(); // Reload recipes to update UI
            }
        }

        // Remove a recipe from the cookbook
        public void RemoveRecipe(Recipe recipe)
        {
            foreach (var cuisine in Cuisines)
            {
                if (cuisine.Recipes.Contains(recipe))
                {
                    cuisine.Recipes.Remove(recipe);
                    SaveToFile(); // Save after removing a recipe
                    break;
                }
            }
        }

        // Update an existing recipe
        public void UpdateRecipe(Recipe oldRecipe, Recipe newRecipe)
        {
            foreach (var cuisine in Cuisines)
            {
                if (cuisine.Recipes.Contains(oldRecipe))
                {
                    var index = cuisine.Recipes.IndexOf(oldRecipe);
                    cuisine.Recipes[index] = newRecipe;
                    newRecipe.Cuisine = cuisine;
                    SaveToFile(); // Save after updating a recipe
                    break;
                }
            }
        }


        public void Load()
        {
            if (!File.Exists(filePath))
            {
                // If the file doesn't exist, initialize with default data
                InitializeWithDefaultData();
                return;
            }

            string jsonData = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(jsonData))
            {
                // If the file is empty, initialize with default data
                InitializeWithDefaultData();
                return;
            }

            try
            {
                // Attempt to deserialize the JSON data
                List<Cuisine> loadedCuisines = JsonConvert.DeserializeObject<List<Cuisine>>(jsonData);

                // If deserialization succeeds, set the loaded cuisines
                if (loadedCuisines != null)
                {
                    Cuisines.Clear();
                    Cuisines.AddRange(loadedCuisines);

                    // Set the Cuisine property for each Recipe
                    foreach (var cuisine in Cuisines)
                    {
                        foreach (var item in cuisine.Recipes)
                        {
                            item.Cuisine = cuisine;
                        }
                    }
                }
                else
                {
                    // If deserialization fails, initialize with default data
                    InitializeWithDefaultData();
                }
            }
            catch (JsonException ex)
            {
                // If an exception occurs during deserialization, log the error
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                // Initialize with default data
                InitializeWithDefaultData();
            }
        }


        private void InitializeWithDefaultData()
        {
            // Initialize with default data
            Cuisines.Clear();
            Cuisines.AddRange(new List<Cuisine>()
            {
                new Cuisine
                {
                    Name = "Khmer",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Title = "Samlor Korko",
                            Description = "Khmer Soup",
                            Ingredients = new List<string> { "Papaya", "Pork", "...." },
                            Steps = new List<string> { "1. ...", "2. ...." },
                            Type = "Soup",
                            Images = new List<string> { "https://shorturl.at/cwxzN" }
                        },
                        new Recipe
                        {
                            Title = "Grill Fish",
                            Description = "Drill the fish",
                            Ingredients = new List<string> { "Fish", "Ginger", "...." },
                            Steps = new List<string> { "1. ...", "2. ...." },
                            Type = "Grill",
                            Images = new List<string> { "https://shorturl.at/egvJW"}
                        }
                    }
                },
                new Cuisine { Name = "Vietnam" },
                new Cuisine { Name = "Thai" }
            });
        }

        public void SaveToFile()
        {
            try
            {
                // Serialize the Cuisines list into JSON format and write it to the file
                File.WriteAllText(filePath, JsonConvert.SerializeObject(Cuisines, Formatting.Indented));
                Load();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during file writing
                Console.WriteLine($"Error saving data to file: {ex.Message}");
            }
        }
        public Recipe FindRecipeByTitle(string title)
        {
            foreach (var cuisine in Cuisines)
            {
                var recipe = cuisine.Recipes.FirstOrDefault(r => r.Title == title);
                if (recipe != null)
                {
                    return recipe;
                }
            }
            return null; // Recipe not found
        }

        public Cuisine FindCuisineByName(string name)
        {
            return Cuisines.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
