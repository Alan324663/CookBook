using CookBook_Application_Exam.EditCookBook;
using CookBook_Application_Exam.Models;
using CookBook_Application_Exam.Views;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CookBook_Application_Exam
{
    public partial class MainWindow : Window
    {
        private readonly CookBook cookBook;

        public MainWindow()
        {
            InitializeComponent();
            cookBook = new CookBook(); // Create a new instance
            cookBook.Load(); // Load data from the file
            DataContext = cookBook; // Set DataContext to the existing cookBook instance
        }



        private void OpenCookBookButton_Click(object sender, RoutedEventArgs e)
        {
            OpenBookUC openBookUC = new OpenBookUC();
            openBookUC.DataContext = cookBook; // Pass existing cookBook instance
            Content = openBookUC;
        }

        private void EditCookBookButton_Click(object sender, RoutedEventArgs e)
        {
            EditCookBookUC editCookUC = new EditCookBookUC(cookBook);
            Content = editCookUC;
        }
    }

}
