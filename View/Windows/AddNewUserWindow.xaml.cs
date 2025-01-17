﻿using Hotel1.Appdata;
using Hotel1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

namespace Hotel1.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        public AddNewUserWindow()
        {
            InitializeComponent();
        }

        public void AddUser()
        {
            try
            {
                if (string.IsNullOrEmpty(FullnameTb.Text) ||
                string.IsNullOrEmpty(LoginTb.Text) ||
                string.IsNullOrEmpty(PasswordPb.Password))
                {
                    FeedbackClass.Warning("Все поля обязательны для заполнения!");
                }

                else
                {
                    User newUser = new User()
                    {
                        Fullname = FullnameTb.Text,
                        Login = LoginTb.Text,
                        Password = PasswordPb.Password,
                        RegistrationDate = DateTime.Now,
                        IsActivated = false,
                        IsBlocked = false,
                        RoleId = 2
                    };
                    App.context.User.Add(newUser);
                    App.context.SaveChanges();

                    FeedbackClass.Informatiom("Пользователь успешно добавлен!");

                    DialogResult = true;

                }
            }
            catch (DbUpdateException exception)
            {
                FeedbackClass.Error($"Пользователь с таким логином уже существует. {exception.Message}");
                DialogResult = false;
            }
            catch (Exception exception)
            {
                FeedbackClass.Error($"Ошибка при добавлении пользователя. {exception.Message}");
            }
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
