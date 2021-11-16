using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
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

        private bool ValidateInput()
        {
            if(
                String.IsNullOrWhiteSpace(titleTextbox.Text) ||
                (String.IsNullOrWhiteSpace(descriptionTextbox.Text) && String.IsNullOrWhiteSpace(contentPath.Content.ToString()))
            )
            {
                return false;
            }
            return true;
        }

        private void CreatePost()
        {
            Post newPost = new Post();
            newPost.IdUser = loggedUser.IdUser;
            newPost.CreationDate = DateTime.UtcNow;
            newPost.Title = titleTextbox.Text;
            newPost.Description = descriptionTextbox.Text;
            newPost.Content = new byte[64];
            newPost.Reactions = 1;
            newPost.PostType = "Default";

            PostDAL.addPost(newPost);
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            if(!ValidateInput())
            {
                MessageBox.Show("Make sure the Title and either a Media File or Description is specified.");
                return;
            }
            try
            {
                CreatePost();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
                return;
            }
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
