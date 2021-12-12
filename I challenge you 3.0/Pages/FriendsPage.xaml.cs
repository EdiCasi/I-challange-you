using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace I_challenge_you_3._0.Pages
{
    public partial class FriendsPage : Page
    {
        public List<User> friends { get; set; }
        public List<User> friendsP { get; set; }
        public FriendsPage()
        {
            InitializeComponent();
            this.friends = UserDAL.getUserFriends(MainWindow.LoggedUser.IdUser);
            this.friendsP = UserDAL.getUserPendingFriends(MainWindow.LoggedUser.IdUser);

            foreach(User user in friendsP)
            {
                FriendPending friend = new FriendPending(user, this);
                friend.Padding = new Thickness(10);
                friendsPanel.Children.Add(friend);
            }

            foreach(User user in friends)
            {
                Friend friend = new Friend(user, this);
                friend.Padding = new Thickness(10);
                friendsPanel.Children.Add(friend);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
