using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Model;
using System.Windows;

namespace I_challenge_you_3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            User user = UserDAL.getUser(username.Text, password.Password);
            if (user == null)
            {
                MessageBox.Show("The username or password you entered are wrong, please check them and try again");
            }
            else
            {
                MessageBox.Show(user.Email + " " + user.Username);
            }
        }
    }
}
