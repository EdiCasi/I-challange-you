﻿using I_challenge_you_3._0.Models;
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
    /// Interaction logic for PostOrChallengePage.xaml
    /// </summary>
    public partial class PostOrChallengePage : Page
    {
        public User loggedUser { get; set; }
        public PostOrChallengePage()
        {
            InitializeComponent();
            loggedUser = MainWindow.LoggedUser;
            DataContext = this;
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePostPage(loggedUser));
        }

        private void Challenge_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateChallengePage(loggedUser));
        }

        private void Response_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectChallengeForResponse());
        }
    }
}
