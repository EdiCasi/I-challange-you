using I_challenge_you_3._0.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace I_challenge_you_3._0.Pages
{
    public partial class FriendProfilePage : Page
    {
        public User friend { get; set; }
        public Brush statusColor { get; set; }
        public FriendProfilePage(User friend)
        {
            InitializeComponent();
            DataContext = this;
            this.friend = friend;
            switch(this.friend.Status)
            {
                case "Available":
                    this.statusColor = new SolidColorBrush(Colors.Green);
                    break;
                case "Away":
                    this.statusColor = new SolidColorBrush(Colors.Yellow);
                    break;
                default:
                    this.statusColor = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
