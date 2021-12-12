using I_challenge_you_3._0.Converters;
using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using Microsoft.Win32;
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

namespace I_challenge_you_3._0.Pages
{
    /// <summary>
    /// Interaction logic for EditPostPage.xaml
    /// </summary>
    public partial class EditPostPage : Page
    {
        public Post EditPost { get; set; }
        private byte[] PostContent = new byte[0];
        private string ContentType = "";
        private string contentPath = "";
        public User ChallengedUser { get; set; }
        private bool playingVideo = false;
        public EditPostPage(Post post)
        {
            InitializeComponent();
            EditPost = post;
            LoadData();
        }

        private void LoadData()
        {
            titleTextbox.Text = EditPost.Title;
            descriptionTextbox.Text = EditPost.Description;
            if(EditPost.ChallengedPerson != null)
            {
                ChallengedUser = UserDAL.getUserById((int)EditPost.ChallengedPerson);
                userTextbox.Text = ChallengedUser.Username;
            }

            if (EditPost.ContentType == "image")
            {
                postImage.Source = ByteImageConverter.ConvertByteArrayToImageSource(this.EditPost.Content);
                postImage.Visibility = Visibility.Visible;
                PostContent = EditPost.Content;
                ContentType = EditPost.ContentType;
            }
            else if (EditPost.ContentType == "video")
            {
                string filePath = "temp/" + string.Format(@"{0}.mp4", "video_post" + EditPost.IdPost);
                if (!File.Exists(filePath))
                {
                    File.WriteAllBytes(filePath, EditPost.Content);
                }
                postVideo.Source = new Uri(filePath, UriKind.Relative);
                postVideo.Visibility = Visibility.Visible;
                PostContent = EditPost.Content;
                ContentType = EditPost.ContentType;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private bool ValidateInput()
        {
            if (
                String.IsNullOrWhiteSpace(titleTextbox.Text) ||
                (String.IsNullOrWhiteSpace(descriptionTextbox.Text) && ContentType == null)
            )
            {
                return false;
            }
            return true;
        }

        private bool UpdatePost()
        {
            EditPost.Title = titleTextbox.Text;
            EditPost.Description = descriptionTextbox.Text;
            EditPost.Content = PostContent;
            EditPost.ContentType = ContentType;
            if(ChallengedUser != null)
            {
                EditPost.ChallengedPerson = ChallengedUser.IdUser;
            }
            else
            {
                EditPost.ChallengedPerson = null;
            }

            if (PostDAL.ChangePost(EditPost))
            {
                return true;
            }
            return false;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Make sure the Title and either a Media File or Description is specified.");
                return;
            }
            if(UpdatePost())
            {
                MessageBox.Show("Post edited successfully!");
                NavigationService.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Error occured trying to update post.");
            }
        }

        private void UploadContent_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg;|Video files (*.mp4)|*.mp4;";
            if (fileDialog.ShowDialog() == true)
            {
                contentPath = fileDialog.FileName;
                if (System.IO.Path.GetExtension(fileDialog.FileName) == ".mp4")
                {

                    PostContent = File.ReadAllBytes(fileDialog.FileName);
                    ContentType = "video";
                    postImage.Visibility = Visibility.Collapsed;
                    postImage.Source = null;
                    postVideo.Visibility = Visibility.Visible;
                    postVideo.Source = new Uri(contentPath, UriKind.Absolute);
                }
                else
                {
                    PostContent = ByteImageConverter.ConvertImageToBytes(System.Drawing.Image.FromFile(fileDialog.FileName));
                    ContentType = "image";
                    postImage.Visibility = Visibility.Visible;
                    postImage.Source = new BitmapImage(new Uri(contentPath, UriKind.Absolute));
                    postVideo.Visibility = Visibility.Collapsed;
                    postVideo.Source = null;
                }
            }
            else
            {
                PostContent = new byte[0];
                ContentType = "";
                postImage.Visibility = Visibility.Collapsed;
                postImage.Source = null;
                postVideo.Visibility = Visibility.Collapsed;
                postVideo.Source = null;
            }
        }

        private void RemoveContent_Click(object sender, RoutedEventArgs e)
        {
            PostContent = new byte[0];
            ContentType = "";
            postImage.Visibility = Visibility.Collapsed;
            postImage.Source = null;
            postVideo.Visibility = Visibility.Collapsed;
            postVideo.Source = null;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchFriendPage(MainWindow.LoggedUser, userTextbox.Text, this, "EditPostPage"));
        }

        private void MediaPlayToggle(object sender, MouseButtonEventArgs e)
        {
            if (playingVideo)
            {
                postVideo.Pause();
                playingVideo = false;
            }
            else
            {
                postVideo.Play();
                playingVideo = true;
            }
        }

        private void MediaLoaded(object sender, RoutedEventArgs e)
        {
            postVideo.Pause();
            playingVideo = false;
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            postVideo.Stop();
            playingVideo = false;
        }
    }
}
