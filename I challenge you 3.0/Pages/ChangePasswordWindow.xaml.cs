using I_challenge_you_3._0.DataAccessLayers;
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
using System.Windows.Shapes;

namespace I_challenge_you_3._0.Pages
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (OldPass.Password == MainWindow.LoggedUser.Pass)
            {
                if (NewPass.Password == ReNewPass.Password)
                {
                    UserDAL.changePassword(MainWindow.LoggedUser.IdUser, NewPass.Password);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The new password was not typed again properly");
                }
            }
            else
            {
                MessageBox.Show("The old password you entered is wrong");
            }
        }
    }
}
