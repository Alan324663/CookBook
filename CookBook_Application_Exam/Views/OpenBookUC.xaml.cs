using System.Windows;
using System.Windows.Controls;
using CookBook_Application_Exam.Models;

namespace CookBook_Application_Exam.Views
{
    public partial class OpenBookUC : UserControl
    {
        public OpenBookUC()
        {
            InitializeComponent();
            LoadRecipes();
        }
        private void LoadRecipes()
        {
            if (DataContext is CookBook cookBook)
            {
                UGRecipeList.Children.Clear(); // Clear existing recipes

                // Check if a cuisine is selected
                if (cookBook.SelectedCuisine != null)
                {
                    // Get the selected cuisine
                    Cuisine selectedCuisine = cookBook.SelectedCuisine;

                    // Find the selected cuisine
                    var cuisine = cookBook.Cuisines.FirstOrDefault(c => c.Name == selectedCuisine.Name);

                    if (cuisine != null)
                    {
                        // Iterate through the recipes of the selected cuisine
                        foreach (Recipe recipe in cuisine.Recipes)
                        {
                            RecipeUC recipeUC = new RecipeUC();
                            recipeUC.DataContext = recipe; // Set the data context of the RecipeUC to the current recipe

                            // Subscribe to the Click event of RecipeUC
                            recipeUC.Click += RecipeUC_Click;

                            UGRecipeList.Children.Add(recipeUC); // Add the RecipeUC to the UniformGrid
                        }
                    }
                }
                else
                {
                    // Load all recipes
                    foreach (Cuisine cuisine in cookBook.Cuisines)
                    {
                        foreach (Recipe recipe in cuisine.Recipes)
                        {
                            RecipeUC recipeUC = new RecipeUC();
                            recipeUC.DataContext = recipe; // Set the data context of the RecipeUC to the current recipe

                            // Subscribe to the Click event of RecipeUC
                            recipeUC.Click += RecipeUC_Click;

                            UGRecipeList.Children.Add(recipeUC); // Add the RecipeUC to the UniformGrid
                        }
                    }
                }
            }
        }


        private void CuisineItem_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if (DataContext is CookBook cookBook)
            {
                TextBlock textBlock = sender as TextBlock;
                if (textBlock != null && textBlock.DataContext is Cuisine selectedCuisine)
                {
                    // Set the selected cuisine in the DataContext
                    cookBook.SelectedCuisine = selectedCuisine;
                    LoadRecipes(); // Load recipes for the selected cuisine
                }
            }
        }

        private void RecipeUC_Click(Recipe clickedRecipe)
        {
            if (clickedRecipe != null)
            {
                RecipeDetail.DataContext = clickedRecipe;
                RecipeDetail.Visibility = Visibility.Visible;
                UGRecipeList.Visibility = Visibility.Hidden;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadRecipes();
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            // Close the current window
            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
