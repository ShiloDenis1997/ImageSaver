using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ImageSaver.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            TargetDirectory = Directory.GetCurrentDirectory();

            InitializeComponent();
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.DecodePixelHeight = 200;
            bitmapImage.UriSource = new Uri(@"C:\Users\USER\Desktop\Спелая клубника\Спелая клубника\DSC_1989.JPG");
            bitmapImage.EndInit();

            for (int i = 0; i < 4; i++)
            {
                imagesPanel.Children.Add(
                    new Image
                    {
                        Source = bitmapImage,
                        Height = bitmapImage.DecodePixelHeight,
                        Margin = new Thickness(10)
                    });
            }
        }

        public string TargetDirectory { get; set; }

        private void changeDestinationButton_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = TargetDirectory;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TargetDirectory = dialog.FileName;
            }
            this.targetDirectory.Content = TargetDirectory.Substring(Math.Max(0, TargetDirectory.Length - 30));
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            this.searchButton.IsEnabled = false;
            string searchString = this.searchTextBox.Text;
            //perform search
            await Task.Delay(1000);
            this.searchButton.IsEnabled = true;
        }
    }
}
