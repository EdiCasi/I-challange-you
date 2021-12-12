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
    /// <summary>
    /// Interaction logic for ChallengedUser.xaml
    /// </summary>
    public partial class ChallengedUser : UserControl
    {
        public User displayedFriend { get; set; }
        public Page page { get; set; }
        public string pageType { get; set; }
        public SearchFriendPage searchFriendPage { get; set; }
        public ChallengedUser(User displayedFriend, Page page, string pageType, SearchFriendPage searchFriendPage)
        {
            InitializeComponent();

            DataContext = this;

            this.displayedFriend = displayedFriend;
            this.page = page;
            this.pageType = pageType;
            this.searchFriendPage = searchFriendPage;
        }

        private void selectFriend(object sender, RoutedEventArgs e)
        {
            switch(pageType)
            {
                case "CreateChallengePage":
                    var convPage = (CreateChallengePage)page;
                    convPage.personTextbox.Text = displayedFriend.Username;
                    convPage.challengedUser = displayedFriend;
                    searchFriendPage.NavigationService.Navigate(convPage);
                    break;
                case "EditPostPage":
                    var editPage = (EditPostPage)page;
                    editPage.userTextbox.Text = displayedFriend.Username;
                    editPage.ChallengedUser = displayedFriend;
                    searchFriendPage.NavigationService.Navigate(editPage);
                    break;
            }
        }
    }
}
