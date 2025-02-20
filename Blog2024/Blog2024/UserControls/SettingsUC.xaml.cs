using Blog2024.Library.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Blog2024.UserControls
{
    public partial class SettingsUC : UserControl
    {
        private User _user;

        public SettingsUC(User user)
        {
            InitializeComponent();
            _user = user;
            FirstName.Text = _user.FirstName;
            LastName.Text = _user.LastName;
            Age.Text = _user.Age.ToString();
            Pseudonym.Text = _user.Pseudonym;
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
                MessageBox.Show("Wiek musi byc liczba!");
                return;
            }

            var mainWindow = (MainWindow)Window.GetWindow(this);
            var updatedUser = new User(firstName, lastName, age, pseudonym);
            mainWindow.SwitchToBlogView(updatedUser);
        }
    }
}
