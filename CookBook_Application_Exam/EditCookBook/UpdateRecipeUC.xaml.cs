using CookBook_Application_Exam.Models;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_Application_Exam.EditCookBook
{
    public partial class UpdateRecipeUC : UserControl
    {
        private readonly CookBook cookBook;
        public UpdateRecipeUC()
        {
            InitializeComponent();
        }
        public UpdateRecipeUC(CookBook cookBook)
        {
            InitializeComponent();
            this.cookBook = cookBook;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the title entered by the user
            string title = RecipeTitleTextBox.Text;

            // Find the recipe in the cookbook
            Recipe recipe = cookBook.FindRecipeByTitle(title);

            // If recipe found, update the DataContext to display it
            if (recipe != null)
            {
                // Create an instance of UpdateRecipeDetailUC with the found recipe and set it as the content
                UpdateRecipeDetailUC updateRecipeDetailUC = new UpdateRecipeDetailUC(recipe, cookBook);
                Content = updateRecipeDetailUC;
            }
            else
            {
                // Recipe not found, display a message
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
