using System;
using System.Windows;
using System.Windows.Controls;
using Blog2024.Library;
using Blog2024.Library.Models;

namespace Blog2024.UserControls
{
    public partial class BlogEntryUC : UserControl
    {
        private User _user;
        private PostManager _postManager;

        public BlogEntryUC(User user)
        {
            InitializeComponent();
            _user = user;
            _postManager = new PostManager();
            UserData.Text = _user.GetUserData();
            DisplayPosts();
        }

        private void CreatePost_Click(object sender, RoutedEventArgs e)
        {
            string content = BlogContent.Text;
            if (!string.IsNullOrWhiteSpace(content))
            {
                try
                {
                    _postManager.AddPost(_user.Pseudonym, content);
                    BlogContent.Clear();
                    DisplayPosts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Napisz jakiś post.");
            }
        }

        private void DisplayPosts()
        {
            BlogPosts.Text = string.Join("\n", _postManager.GetPosts());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SwitchToLoginView();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SwitchToSettingsView(_user);
        }
    }
}
