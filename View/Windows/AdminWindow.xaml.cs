using Hotel1.View.Pages;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            //Открытие страниц внутри файла
            //1. Обратиться к фрейму по имени
            //2. Вызвать метод навигейт
            //3. Передать в качестве значения экземпляр нужной страницы
            MainFrame.Navigate(new UserListPage());
        }

        private void UserBtnn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserListPage());
        }

        private void RoomsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
