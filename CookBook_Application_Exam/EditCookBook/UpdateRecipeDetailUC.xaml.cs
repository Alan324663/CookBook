using CookBook_Application_Exam.Models;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace CookBook_Application_Exam.EditCookBook
{
    public partial class UpdateRecipeDetailUC : UserControl
    {
        private readonly CookBook cookBook;
        private readonly Recipe originalRecipe;
        private EditCookBookUC editCookBookUC; // Reference to the EditCookBookUC

        public UpdateRecipeDetailUC(Recipe recipe, CookBook cookBook)
        {
            InitializeComponent();
            this.cookBook = cookBook;
            this.originalRecipe = recipe;

            // Set the DataContext to the original recipe to populate the UI elements
            DataContext = originalRecipe;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve updated values from UI elements
            originalRecipe.Title = TitleTextBox.Text;
            originalRecipe.Description = DescriptionTextBox.Text;
            originalRecipe.Ingredients = IngredientsTextBox.Text.Split(',').ToList();
            originalRecipe.Steps = StepsTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            originalRecipe.Type = TypeTextBox.Text;
            originalRecipe.Images = ImagesTextBox.Text.Split(',').ToList();

            // Update the recipe in the cookbook
            cookBook.UpdateRecipe(originalRecipe, originalRecipe);

            // Display a message to indicate success
            MessageBox.Show("Recipe updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Save changes to the JSON file
            cookBook.SaveToFile();

            // Set the content of the parent UserControl (where UpdateRecipeDetailUC is hosted) to the EditCookBookUC instance
            var parent = Parent as UserControl;
            if (parent != null)
            {
                // Check if editCookBookUC is initialized
                if (editCookBookUC == null)
                {
                    // If editCookBookUC is null, initialize it
                    editCookBookUC = new EditCookBookUC(cookBook);
                }
                parent.Content = editCookBookUC;
            }
        }
    }
}
