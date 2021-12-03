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
    /// Interaction logic for SearchFriendPage.xaml
    /// </summary>
    public partial class SearchFriendPage : Page
    {
        public User loggedUser { get; set; }
        public CreateChallengePage createChallengePage { get; set; }
        public SearchFriendPage(User loggedUser, string searchedFriend, CreateChallengePage createChallengePage)
        {
            InitializeComponent();

            this.loggedUser = loggedUser;
            this.createChallengePage = createChallengePage;

            searchTextBox.Text = searchedFriend;

            fillTheListOfFriends(searchedFriend);
        }
        private void fillTheListOfFriends(string nameOfFriend)
        {
            // Made the request for searchedFriend firstly
            foreach (User user in UserDAL.getCertainFriends(nameOfFriend, loggedUser.IdUser))
            {
                friendList.Children.Add(new ChallengedUser(user, createChallengePage, this));
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(createChallengePage);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            friendList.Children.Clear();

            if(!String.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                fillTheListOfFriends(searchTextBox.Text);
            }
        }
    }
}
