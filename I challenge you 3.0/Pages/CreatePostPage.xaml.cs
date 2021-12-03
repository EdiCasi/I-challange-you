using I_challenge_you_3._0.Converters;
using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace I_challenge_you_3._0.Pages
{
    /// <summary>
    /// Interaction logic for CreatePostPage.xaml
    /// </summary>
    public partial class CreatePostPage : Page
    {
        private byte[] PostContent = null;
        private string ContentType = null;

        public User loggedUser { get; set; }
        public CreatePostPage(User user)
        {
            InitializeComponent();
            DataContext = this;
            this.loggedUser = user;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
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

        private void CreatePost(User challengedUser)
        {
            Post newPost = new Post();
            newPost.IdUser = loggedUser.IdUser;
            newPost.CreationDate = DateTime.UtcNow;
            newPost.Title = titleTextbox.Text;
            newPost.Description = descriptionTextbox.Text;
            newPost.Content = PostContent;
            newPost.ContentType = ContentType;
            newPost.Reactions = 1;

            if(challengedUser != null)
            {
                newPost.ChallengedPerson = challengedUser.IdUser;
            }
            else
            {
                newPost.ChallengedPerson = null;
            }
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
                CreatePost(null);
            }
            catch(Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
                return;
            }
            MessageBox.Show("Post created successfully!");
            NavigationService.Navigate(new HomePage());
        }

        private void UploadContent_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg;|Video files (*.mp4)|*.mp4;";
            if (fileDialog.ShowDialog() == true)
            {
                contentPath.Content = fileDialog.FileName;
                if(System.IO.Path.GetExtension(fileDialog.FileName) == ".mp4")
                {

                    PostContent = File.ReadAllBytes(fileDialog.FileName);
                    ContentType = "video";
                }
                else
                {
                    PostContent = ByteImageConverter.ConvertImageToBytes(System.Drawing.Image.FromFile(fileDialog.FileName));
                    ContentType = "image";
                }
            }
            else
            {
                PostContent = null;
                ContentType = null;
            }
        }
    }
}
