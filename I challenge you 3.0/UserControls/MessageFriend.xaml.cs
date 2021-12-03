using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace I_challenge_you_3._0.UserControls
{
    public partial class MessageFriend : UserControl
    {
        public User Friend { get; set; }
        public MessagesPage Page { get; set; }
        public MessageFriend(User friend, MessagesPage page)
        {
            InitializeComponent();

            DataContext = this;
            this.Friend = friend;
            this.Page = page;
        }

        private void MessageFriend_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessagesPage.LoadMessages(Friend, Page);
        }
    }
}
