using I_challenge_you_3._0.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CreatePostPage.xaml
    /// </summary>
    public partial class CreatePostPage : Page
    {
        public User loggedUser { get; set; }
        public CreatePostPage(User user)
        {
            InitializeComponent();
            loggedUser = user;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage(loggedUser));
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Title: " + titleTextbox.Text + "\n\nDescription: " + descriptionTextbox.Text + "\n\nContent Path: " + contentPath.Content);
            MessageBox.Show("Post created successfully!");
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
