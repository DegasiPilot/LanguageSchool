using LanguageSchool.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var path = @"C:\Users\222119\Downloads\Task\Сессия 1\services_s_import\";
            //foreach(var item in App.db.Service.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImage = imageByte;
            //}
        }

        private void UslugiButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServiceListPage());
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.IsAdmin)
            {
                App.IsAdmin = false;
                AdminBtnText.Text = "Вкл. режим администратора";
                MainFrame.Navigate(new ServiceListPage());
            }
            else
            {
                if(AdminPb.Password == "0000")
                {
                    App.IsAdmin = true;
                    AdminBtnText.Text = "Выкл. режим администратора";
                    AdminPb.Clear();
                    MainFrame.Navigate(new ServiceListPage());
                }
                else
                {
                    MessageBox.Show("Неправильный пароль!");
                }
            }
        }
    }
}
