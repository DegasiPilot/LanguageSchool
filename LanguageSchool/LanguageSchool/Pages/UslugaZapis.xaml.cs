using LanguageSchool.Components;
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

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для UslugaZapis.xaml
    /// </summary>
    public partial class UslugaZapis : Page
    {
        Service service;

        public UslugaZapis(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = _service;
            ClientCb.ItemsSource = App.db.Client.ToList();
            ClientCb.DisplayMemberPath = "FullName";
            DateDp.DisplayDateStart = DateTime.Today;
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
