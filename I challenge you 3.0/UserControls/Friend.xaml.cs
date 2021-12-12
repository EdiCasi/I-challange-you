using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
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

namespace I_challenge_you_3._0.UserControls
{
    public partial class Friend : UserControl
    {
        public  User displayedFriend { get; set; }
        public FriendsPage page { get; set; }


        public Friend(User displayedFriend, FriendsPage page)
        {
            InitializeComponent();

            DataContext = this;

            this.displayedFriend = displayedFriend;
            this.page = page;
        }

        private void GoToProfile(object sender, RoutedEventArgs e)
        {
            page.NavigationService.Navigate(new FriendProfilePage(displayedFriend));
        }

        private void RemoveFriend_Click(object sender, RoutedEventArgs e)
        {
            if(FriendshipDAL.RemoveFriendship(MainWindow.LoggedUser, this.displayedFriend))
            {
                ((Panel)this.Parent).Children.Remove(this);
            }
            else
            {
                MessageBox.Show("Error occured trying to remove friend.");
            }
        }
    }
}
