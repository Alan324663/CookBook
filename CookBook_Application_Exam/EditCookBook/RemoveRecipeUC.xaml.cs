using CookBook_Application_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookBook_Application_Exam.EditCookBook
{
    /// <summary>
    /// Interaction logic for RemoveRecipeUC.xaml
    /// </summary>
    public partial class RemoveRecipeUC : UserControl
    {
        private readonly CookBook cookBook;
        public RemoveRecipeUC()
        {
            InitializeComponent();

        }
        public RemoveRecipeUC(CookBook cookBook)
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
                // Create an instance of RemoveRecipeDetailUC with the found recipe and set it as the content
                RemoveRecipeDetailUC removeRecipeDetailUC = new RemoveRecipeDetailUC(recipe, cookBook);
                Content = removeRecipeDetailUC;
            }

            else
            {
                // Recipe not found, display a message
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
