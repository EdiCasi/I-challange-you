using I_challenge_you_3._0.Models;
using System.IO;
using System.Windows;

namespace I_challenge_you_3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User LoggedUser { get; set; }
        public static HomePage HomePage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Directory.Delete("temp",true);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory("temp");
        }
    }
}
