using CookBook_Application_Exam.Models;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace CookBook_Application_Exam.Views
{
    public partial class RecipeUC : UserControl
    {
        public Recipe Recipe { get; private set; }

        public event Action<Recipe> Click;

        public RecipeUC()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Recipe = DataContext as Recipe;
            Click?.Invoke(Recipe); // Pass the clicked recipe to the event handler
        }
    }
}
