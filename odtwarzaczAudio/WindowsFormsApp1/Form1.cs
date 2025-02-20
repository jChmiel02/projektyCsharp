using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer player;
        public Form1()
        {
            InitializeComponent();
            player = new WindowsMediaPlayer();
            lblCurrentFile.Text = "Nie wybrano żadnego pliku";
            player.PlayStateChange += Player_PlayStateChange;

        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.SelectedItem != null)
            {
                player.URL = lstPlaylist.SelectedItem.ToString();
                player.controls.play();
                lblCurrentFile.Text = $"Aktualnie: {System.IO.Path.GetFileName(player.URL)}";
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego pliku do odtworzenia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
                lblCurrentFile.Text = "Wstrzymano";
            }
            else if (player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.play();
                lblCurrentFile.Text = $"Aktualnie: {System.IO.Path.GetFileName(player.URL)}";
            }
            else
            {
                MessageBox.Show("Nie odtwarzany jest żaden plik.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying || player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.stop();
                lblCurrentFile.Text = "Zatrzymano";
            }
            else
            {
                MessageBox.Show("Nie odtwarzany jest żaden plik.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Pliki audio|*.mp3;*.wav;*.wma|Wszystkie pliki|*.*";
                ofd.Title = "Wybierz plik audio";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lstPlaylist.Items.Add(ofd.FileName);
                }
            }
        }
        private void btnDelFile_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.SelectedItem != null)
            {
                lstPlaylist.Items.Remove(lstPlaylist.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego pliku do usunięcia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lstPlaylist_DoubleClick(object sender, EventArgs e)
        {
            if (lstPlaylist.SelectedItem != null)
            {
                player.URL = lstPlaylist.SelectedItem.ToString();
                player.controls.play();
                lblCurrentFile.Text = $"Aktualnie: {System.IO.Path.GetFileName(player.URL)}";
            }
        }
        private void Player_PlayStateChange(int newState)
        {
            if ((WMPPlayState)newState == WMPPlayState.wmppsMediaEnded)
            {
                PlayNextFile();
            }
        }


        private async void PlayNextFile()
        {
            if (lstPlaylist.SelectedIndex < lstPlaylist.Items.Count - 1)
            {
                lstPlaylist.SelectedIndex++;
                string nextFile = lstPlaylist.SelectedItem.ToString();
                player.URL = nextFile;
                lblCurrentFile.Text = $"Aktualnie: {System.IO.Path.GetFileName(nextFile)}";
                await Task.Delay(100);
                player.controls.play();
            }
            else
            {
                player.controls.stop();
                lblCurrentFile.Text = "Odtwarzanie zakończone";
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying || player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.currentPosition += 5;
            }
            else
            {
                MessageBox.Show("Nie odtwarzany jest żaden plik.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRewind_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying || player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.currentPosition -= 5;

                if (player.controls.currentPosition < 0)
                {
                    player.controls.currentPosition = 0;
                }
            }
            else
            {
                MessageBox.Show("Nie odtwarzany jest żaden plik.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void lblCurrentFile_Click(object sender, EventArgs e) { }
    }
}
