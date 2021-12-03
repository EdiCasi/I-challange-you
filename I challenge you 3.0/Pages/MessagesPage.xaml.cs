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
    public partial class MessagesPage : Page
    {
        public User MessagesFriend { get; set; }
        public MessagesPage()
        {
            InitializeComponent();
            DataContext = this;

            LoadFriends();
        }

        public void LoadFriends()
        {
            List<User> friends = UserDAL.getUserFriends(MainWindow.LoggedUser.IdUser);

            foreach (var friend in friends)
            {
                MessageFriend messageFriend = new MessageFriend(friend, this);
                messageFriend.Padding = new Thickness(10);
                friendPanel.Children.Add(messageFriend);
            }
        }

        public static void LoadMessages(User friend, MessagesPage page)
        {
            page.MessagesFriend = friend;
            page.messageUsername.Content = friend.Username;
            page.messagePanel.Children.Clear();
            page.messageText.Text = "";
            List<Message> Messages = MessageDAL.getMessages(MainWindow.LoggedUser, page.MessagesFriend);

            foreach (var message in Messages)
            {
                MessageControl messageControl = new MessageControl(message);
                messageControl.HorizontalAlignment = message.Sender.IdUser == MainWindow.LoggedUser.IdUser ? HorizontalAlignment.Right : HorizontalAlignment.Left;
                messageControl.Padding = new Thickness(10);
                page.messagePanel.Children.Add(messageControl);
            }

            page.messagesGrid.Visibility = Visibility.Visible;
            page.messagesScroll.ScrollToEnd();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(messageText.Text))
            {
                Message message = new Message()
                {
                    Sender = MainWindow.LoggedUser,
                    Receiver = MessagesFriend,
                    Text = messageText.Text,
                    CreationDate = DateTime.UtcNow
                };
                MessageDAL.createMessage(message);

                LoadMessages(MessagesFriend, this);
                messageText.Text = "";
            }
        }
    }
}
