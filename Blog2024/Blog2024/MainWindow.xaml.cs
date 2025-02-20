using System.Windows;
using Blog2024.UserControls;
using Blog2024.Library.Models;

namespace Blog2024
{
    public partial class MainWindow : Window
    {
        private LoginUC _loginUC;
        private BlogEntryUC _blogEntryUC;
        private SettingsUC _settingsUC;

        public MainWindow()
        {
            _loginUC = new LoginUC();
            InitializeComponent();
            SetLoginView();
        }

        private void SetLoginView()
        {
            this.MainContent.Content = _loginUC;
        }

        public void SwitchToBlogView(User user)
        {
            _blogEntryUC = new BlogEntryUC(user);
            this.MainContent.Content = _blogEntryUC;
        }

        public void SwitchToLoginView()
        {
            _loginUC.ClearFields();
            this.MainContent.Content = _loginUC;
        }

        public void SwitchToSettingsView(User user)
        {
            _settingsUC = new SettingsUC(user);
            this.MainContent.Content = _settingsUC;
        }
    }
}
