using CookBook_Application_Exam.Models;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;

namespace CookBook_Application_Exam.EditCookBook
{
    public partial class RemoveRecipeDetailUC : UserControl
    {
        private readonly CookBook cookBook;
        private readonly Recipe recipeToRemove;
        private EditCookBookUC editCookBookUC; // Reference to the EditCookBookUC

        public RemoveRecipeDetailUC(Recipe recipe, CookBook cookBook)
        {
            InitializeComponent();
            this.cookBook = cookBook;
            this.recipeToRemove = recipe;

            // Set the DataContext to the recipe to populate the UI elements
            DataContext = recipeToRemove;
        }
        public RemoveRecipeDetailUC(CookBook cookBook, EditCookBookUC editCookBookUC)
        {
            InitializeComponent();
            this.cookBook = cookBook;
            this.editCookBookUC = editCookBookUC;
        }
       
        public RemoveRecipeDetailUC()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            editCookBookUC = new EditCookBookUC();
            // Remove the recipe from the cookbook
            cookBook.RemoveRecipe(recipeToRemove);
            cookBook.SaveToFile();
            // Optionally, display a message to indicate success
            MessageBox.Show("Recipe removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            var parent = Parent as UserControl;
            if (parent != null)
            {
                parent.Content = editCookBookUC;
            }
            

        }
        
    }
}
