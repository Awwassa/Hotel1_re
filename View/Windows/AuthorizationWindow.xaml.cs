using Hotel1.Appdata;
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

namespace Hotel1.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            BlockingUserByDate();
        }

        public void BlockingUserByDate()
        {

            foreach (var user in App.context.User)
            {
                if (user.RegistrationDate.AddMonths(1) < DateTime.Now && !user.IsActivated)
                {
                    user.IsBlocked = true;
                }
            }
        }

        public bool Validation()

        {
            return true;

            if (LoginTb.Text == string.Empty && PasswordTb.Password == string.Empty)
            {
                FeedbackClass.Warning("Поля для ввода логина и пароля обязательны для заполнения. Введите логин и пароль.");
                return false;
            }
            else if (LoginTb.Text == string.Empty)
            {
                FeedbackClass.Warning("Поля для ввода логина обязательно для заполнения. Введите логин");
                return false;
            }
            else if (PasswordTb.Password == string.Empty)
            {
                FeedbackClass.Warning("Поля для ввода пароль бязательно для заполнения. Введите пароль");
                return false;
            }


        }

        public void Authentication()
        {
            //Проверка
            App.currentUser = App.context.User.FirstOrDefault(user => user.Login == LoginTb.Text && user.Password == PasswordTb.Password);

            if (App.currentUser == null)
            {
                // LoginAttemptCount++;

                FeedbackClass.Error($"Вы ввели неверный логин или пароль. Пожалуйста, проверьте еще раз введеные данные! Попытка: {LoginAttemptCount} из 3");

                //   if (LoginAttemptCount == 3)
                //   {
                //  App.currentUser.IsBlocked = true;
                //     LoginAttemptCount = 0;
                //     Feedback.Error("Вы заблокированы. Обратитесь к администратору");
                //   Close();
                //   } 
            }
            else if (App.currentUser.IsBlocked == true)
            {
                FeedbackClass.Error("Вы заблокированы");
            }
            else if (App.currentUser.IsActivated == false)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.Show();
                Hide();
            }
            else
            {
                FeedbackClass.Informatiom("Вы успешно авторизовались");
                Authorization();
            }

        }

        public void Authorization()
        {
            switch (App.currentUser.RoleId)
            {
                case 1:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    break;
                case 2:
                    FeedbackClass.Informatiom("Вход в качестве пользователя");
                    break;
                default:
                    FeedbackClass.Error("Доступ запрещен!");
                    break;
            }
            Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                Authentication();

            }
        }
    }
}
