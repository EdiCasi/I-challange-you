using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.UserControls;
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
    /// Interaction logic for SelectChallengeForResponse.xaml
    /// </summary>
    public partial class SelectChallengeForResponse : Page
    {
        public SelectChallengeForResponse()
        {
            InitializeComponent();
            DataContext = this;
            LoadPosts();
        }

        public void LoadPosts()
        {
            List<Post> posts = PostDAL.getChallenges(MainWindow.LoggedUser.IdUser);

            foreach (var post in posts)
            {
                
                DisplayPost displayPost = new DisplayPost(post , new HomePage());

                displayPost.contentContainer.Visibility = Visibility.Collapsed;
                displayPost.reactionsContainer.Visibility = Visibility.Collapsed;
                displayPost.MouseDoubleClick += DisplayPost_MouseDoubleClick;
                displayPost.Padding = new Thickness(20);
                postPanel.Children.Add(displayPost);
            }
        }

        private void DisplayPost_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var displayedPost = (DisplayPost)sender;
            displayedPost.usernameLabel.Content = "Clicked";
            CreateResponse createResponse = new CreateResponse(MainWindow.LoggedUser);

            createResponse.titleTextbox.Text = (string)displayedPost.titleLabel.Content;
            createResponse.titleTextbox.IsEnabled = false;
            createResponse.responseToId = displayedPost.post.IdPost;

            NavigationService.Navigate(createResponse);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PostOrChallengePage());
        }
    }
}
