using I_challenge_you_3._0.Models;
using Microsoft.Win32;
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

namespace I_challenge_you_3._0.Pages
{
    /// <summary>
    /// Interaction logic for CreateChallengePage.xaml
    /// </summary>
    public partial class CreateChallengePage : Page
    {
        public User loggedUser { get; set; }
        public CreateChallengePage(User user)
        {
            InitializeComponent();
            loggedUser = user;
            DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage(loggedUser));
        }

        private void UploadContent_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg;|Video files (*.mp4)|*.mp4;";
            if (fileDialog.ShowDialog() == true)
            {
                contentPath.Content = fileDialog.FileName;
            }
        }
    }
}
