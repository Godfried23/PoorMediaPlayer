using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;

namespace PoorMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private readonly OpenFileDialog dlg = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            dlg.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                mediaPlayer.Open(new Uri(dlg.FileName));
                songTitle.Content = dlg.SafeFileName.TrimEnd('.', 'm', 'p', '3');
            }
        }

        #region MediaControls      
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
        #endregion
    }
}
