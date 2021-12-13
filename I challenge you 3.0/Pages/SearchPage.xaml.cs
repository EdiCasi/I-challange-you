using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace I_challenge_you_3._0.Pages
{
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            searchedPanel.Children.Clear();

            List<User> foundUsers = UserDAL.searchUsers(searchBox.Text);
            List<User> friends = UserDAL.getUserFriends(MainWindow.LoggedUser.IdUser);
            List<User> pendingFriends = UserDAL.getUserOutboundRequests(MainWindow.LoggedUser.IdUser);

            if(foundUsers.Count != 0 )
            {
                foreach(User foundUser in foundUsers)
                {

                    if (foundUser.Username != MainWindow.LoggedUser.Username && friends.Find(friend => friend.IdUser == foundUser.IdUser) == null && pendingFriends.Find(friend => friend.IdUser == foundUser.IdUser) == null)
                    {
                        SearchedUser searchedUser = new SearchedUser(foundUser);
                        searchedUser.Padding = new Thickness(10);
                        searchedPanel.Children.Add(searchedUser);
                    }
                }
            }
            foreach(User friend in friends)
            {
                Friend fr = new Friend(friend, this);
                fr.Padding = new Thickness(10);
                searchedPanel.Children.Add(fr);
            }    
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
