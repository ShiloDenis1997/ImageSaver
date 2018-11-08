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

namespace ImageSaver.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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
    }
}
