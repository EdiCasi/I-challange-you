using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
using System.Windows;
using System.Windows.Controls;
using I_challenge_you_3._0.DataAccessLayers;
namespace I_challenge_you_3._0.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class FriendPending : UserControl
    {
        public User displayedFriend { get; set; }
        public FriendsPage page { get; set; }


        public FriendPending(User displayedFriend, FriendsPage page)
        {
            InitializeComponent();

            DataContext = this;

            this.displayedFriend = displayedFriend;
            this.page = page;
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            FriendshipDAL.acceptRequest(MainWindow.LoggedUser.IdUser, displayedFriend.IdUser);
            ((Panel)this.Parent).Children.Remove(this);
            this.page.friendsPanel.Children.Add(new Friend(displayedFriend, page));
            MainWindow.HomePage = new HomePage();

            MainWindow.HomePage.LoadNotificationCount();
        }

        private void Reject(object sender, RoutedEventArgs e)
        {
            FriendshipDAL.rejectRequest(MainWindow.LoggedUser.IdUser, displayedFriend.IdUser);
            ((Panel)this.Parent).Children.Remove(this);

            MainWindow.HomePage.LoadNotificationCount();
        }
    }
}
