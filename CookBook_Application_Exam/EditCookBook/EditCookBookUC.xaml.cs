using CookBook_Application_Exam.Models;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_Application_Exam.EditCookBook
{
    public partial class EditCookBookUC : UserControl
    {
        private readonly CookBook cookBook;
        private AddRecipeUC addRecipeUC; // Initialize this field
        public event EventHandler RecipeAdded;

        private void NotifyRecipeAdded()
        {
            RecipeAdded?.Invoke(this, EventArgs.Empty);
        }
        public EditCookBookUC()
        {
            InitializeComponent();
            cookBook = new CookBook(); // Initialize cookBook
            addRecipeUC = new AddRecipeUC(cookBook, this); // Initialize addRecipeUC
        }

        // Constructor that accepts a CookBook argument
        public EditCookBookUC(CookBook cookBook)
        {
            InitializeComponent();
            this.cookBook = cookBook; // Initialize cookBook with the provided value
            addRecipeUC = new AddRecipeUC(cookBook, this); // Initialize addRecipeUC
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Since addRecipeUC is already initialized, just set the content
            Content = addRecipeUC;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateRecipeUC updateUC = new UpdateRecipeUC(cookBook);
            Content = updateUC;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveRecipeUC removeUC = new RemoveRecipeUC(cookBook);
            Content = removeUC;
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

