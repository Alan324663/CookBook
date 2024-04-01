using CookBook_Application_Exam.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
namespace CookBook_Application_Exam.EditCookBook
{
    public partial class AddRecipeUC : UserControl
    {
        private EditCookBookUC editCookBookUC; // Reference to the EditCookBookUC
        private readonly CookBook cookBook;

        // Constructor that accepts CookBook and EditCookBookUC instances
        public AddRecipeUC(CookBook cookBook, EditCookBookUC editCookBookUC)
        {
            InitializeComponent();
            this.cookBook = cookBook;
            this.editCookBookUC = editCookBookUC;
        }


        // Parameterless constructor
        public AddRecipeUC()
        {
            InitializeComponent();
        }
        private const string filePath = "MyData.json";

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            // Initialize editCookBookUC when it's needed
            editCookBookUC = new EditCookBookUC();

            string title = RecipeTitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string ingredients = IngredientsTextBox.Text;
            string steps = StepsTextBox.Text;
            string type = TypeTextBox.Text;
            string images = ImagesTextBox.Text;

            // Get the selected cuisine from the ComboBox
            string cuisineName = (CuisineComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            // Ensure a cuisine is selected
            if (string.IsNullOrEmpty(cuisineName))
            {
                MessageBox.Show("Please select a cuisine.");
                return;
            }

            // Find the selected cuisine from the cookbook
            Cuisine selectedCuisine = cookBook.FindCuisineByName(cuisineName);

            if (selectedCuisine == null)
            {
                MessageBox.Show("Selected cuisine not found in the cookbook.");
                return;
            }

            // Split ingredients, steps, and images into lists
            List<string> ingredientsList = new List<string>(ingredients.Split(','));
            List<string> stepsList = new List<string>(steps.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            List<string> imagesList = new List<string>(images.Split(','));

            // Create a new Recipe object
            Recipe newRecipe = new Recipe
            {
                Title = title,
                Description = description,
                Ingredients = ingredientsList,
                Steps = stepsList,
                Type = type,
                Images = imagesList
            };

            // Add the new recipe to the selected cuisine
            cookBook.AddRecipe(newRecipe, selectedCuisine);

            // Optionally, you can display a message box to confirm the addition
            MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            cookBook.SaveToFile();


            // Set the content of the parent UserControl (where AddRecipeUC is hosted) to the EditCookBookUC instance
            var parent = Parent as UserControl;
            if (parent != null)
            {
                parent.Content = editCookBookUC;
            }
        }
    }
}