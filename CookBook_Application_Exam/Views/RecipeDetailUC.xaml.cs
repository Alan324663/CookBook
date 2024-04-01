using CookBook_Application_Exam.Models;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_Application_Exam.Views
{
    public partial class RecipeDetailUC : UserControl
    {
        public RecipeDetailUC()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                // Navigate back to the OpenBookUC
                mainWindow.Content = new OpenBookUC();
            }
        }
    }
}
