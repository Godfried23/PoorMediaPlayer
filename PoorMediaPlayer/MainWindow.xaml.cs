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

namespace PoorMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnClickOpen(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                mediaPlayer.Open(new Uri(dlg.FileName));
                songTitle.Content = dlg.SafeFileName.TrimEnd('.', 'm', 'p', '3');
            }
        }

        private void PlayButton_OnClick(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void PauseButton_OnClick(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}
