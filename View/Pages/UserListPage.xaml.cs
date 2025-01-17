﻿using Hotel1.Appdata;
using Hotel1.Model;
using Hotel1.View.Windows;
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

namespace Hotel1.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        const int USER_ROLE_ID = 2;
        public UserListPage()
        {
            InitializeComponent();
            UserLv.ItemsSource = App.context.User.Where(u => u.RoleId == 2).ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            if (addNewUserWindow.ShowDialog() == true)
            {
                UserLv.ItemsSource = App.context.User.Where(u => u.RoleId == USER_ROLE_ID).ToList();
            }

        }

        private void UserLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDetailsGrid.DataContext = UserLv.SelectedItem as User;
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            FeedbackClass.Informatiom("Информация успешно изменена!");
        }
    }
}
