using System;
using System.Windows;
using System.Windows.Controls;
using Blog2024.Library;
using Blog2024.Library.Models;

namespace Blog2024.UserControls
{
    public partial class LoginUC : UserControl
    {
        public LoginUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string ageText = Age.Text;
            string pseudonym = Pseudonym.Text;
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(ageText) || string.IsNullOrWhiteSpace(pseudonym))
            {
                MessageBox.Show("Podaj wszystkie dane");
                return;
            }
            if (!int.TryParse(ageText, out int age))
            {
                MessageBox.Show("Wiek musi być liczbą!");
                return;
            }

            var user = new User(firstName, lastName, age, pseudonym);
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SwitchToBlogView(user);
        }

        public void ClearFields()
        {
            FirstName.Clear();
            LastName.Clear();
            Age.Clear();
            Pseudonym.Clear();
        }
    }
}
