using I_challenge_you_3._0.Converters;
using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
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

namespace I_challenge_you_3._0.UserControls
{
    /// <summary>
    /// Interaction logic for DisplayPost.xaml
    /// </summary>
    public partial class DisplayPost : UserControl
    {
        private bool playingVideo;
        public Post post { get; set; }
        public User postUser { get; set; }
        public User challengedPerson { get; set; }
        public User loggedUser { get; set; }
        private Page page { get; set; }
        public DisplayPost(Post post, Page page)
        {
            InitializeComponent();
            loggedUser = MainWindow.LoggedUser;
            DataContext = this;
            this.post = post;
            postUser = UserDAL.getUserById(post.IdUser);
            this.page = page;

            LoadContent();
        }


        private void LoadContent()
        {
            if(post.ContentType == "image" && this.post.Content !=null)
            {
                postImage.Source = ByteImageConverter.ConvertByteArrayToImageSource(this.post.Content);
                postImage.Visibility = contentContainer.Visibility = Visibility.Visible;
            }
            else if(post.ContentType == "video" && this.post.Content != null)
            {
                string filePath = "temp/" + string.Format(@"{0}.mp4", "video_post" + post.IdPost);
                if (!File.Exists(filePath))
                {
                    File.WriteAllBytes(filePath, post.Content);
                }
                postVideo.Source = new Uri(filePath, UriKind.Relative);
                postVideo.Visibility = contentContainer.Visibility = Visibility.Visible;
            }

            if(!String.IsNullOrWhiteSpace(post.Description))
            {
                descriptionLabel.Visibility = Visibility.Visible;
            }

            if(postUser.IdUser == MainWindow.LoggedUser.IdUser)
            {
                removePost.Visibility = Visibility.Visible;
                editPost.Visibility = Visibility.Visible;
            }

            likeLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "like");
            loveLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "love");
            angryLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "angry");
            laughLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "laugh");

            if (post.ChallengedPerson != null)
            {
                challengeFor.Visibility = Visibility.Visible;
                challengedPersonName.Visibility = Visibility.Visible;
                challengedPerson = UserDAL.getUserById((int)post.ChallengedPerson);
            }

            if (post.responseTo != null)
            {
                challengeFor.Content = "Response!";
                challengeFor.Visibility = Visibility.Visible;
            }
        }

        private void MediaPlayToggle(object sender, MouseButtonEventArgs e)
        {
            if(playingVideo)
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

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            if(ReactionDAL.verifyUserReaction(loggedUser.IdUser, post.IdPost) == 0)
            {
                ReactionDAL.addReaction(loggedUser.IdUser, post.IdPost, "like");
                likeLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "like");
            }
            else
            {
                ReactionDAL.modifyUserReaction(loggedUser.IdUser, post.IdPost, "like");
                likeLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "like");
                loveLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "love");
                angryLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "angry");
                laughLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "laugh");
            }
        }

        private void Love_Click(object sender, RoutedEventArgs e)
        {
            if (ReactionDAL.verifyUserReaction(loggedUser.IdUser, post.IdPost) == 0)
            {
                ReactionDAL.addReaction(loggedUser.IdUser, post.IdPost, "love");
                loveLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "love");
            }
            else
            {
                ReactionDAL.modifyUserReaction(loggedUser.IdUser, post.IdPost, "love");
                loveLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "love");
                likeLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "like");
                angryLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "angry");
                laughLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "laugh");
            }
        }

        private void Angry_Click(object sender, RoutedEventArgs e)
        {
            if (ReactionDAL.verifyUserReaction(loggedUser.IdUser, post.IdPost) == 0)
            {
                ReactionDAL.addReaction(loggedUser.IdUser, post.IdPost, "angry");
                angryLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "angry");
            }
            else
            {
                ReactionDAL.modifyUserReaction(loggedUser.IdUser, post.IdPost, "angry");
                angryLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "angry");
                likeLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "like");
                loveLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "love");
                
                laughLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "laugh");
            }
        }

        private void Laugh_Click(object sender, RoutedEventArgs e)
        {
            if (ReactionDAL.verifyUserReaction(loggedUser.IdUser, post.IdPost) == 0)
            {
                ReactionDAL.addReaction(loggedUser.IdUser, post.IdPost, "laugh");
                laughLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "laugh");
            }
            else
            {
                ReactionDAL.modifyUserReaction(loggedUser.IdUser, post.IdPost, "laugh");
                laughLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "laugh");
                likeLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "like");
                loveLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "love");
                angryLabel.Content = ReactionDAL.getNumberOfReactions(post.IdPost, "angry");
            }
        }

        private void RemovePost_Click(object sender, RoutedEventArgs e)
        {
            if(PostDAL.RemovePost(post))
            {
                ((Panel)this.Parent).Children.Remove(this);
            }
            else
            {
                MessageBox.Show("Error occured trying to remove post.");
            }
        }

        private void EditPost_Click(object sender, RoutedEventArgs e)
        {
            page.NavigationService.Navigate(new EditPostPage(post));
        }
    }
}