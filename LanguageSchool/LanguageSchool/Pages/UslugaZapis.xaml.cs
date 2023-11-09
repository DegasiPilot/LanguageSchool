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
            if(ClientCb.SelectedItem != null && DateDp.SelectedDate != null && StartTimeTb.Text != "")
            {
                var startDate =$"{DateDp.SelectedDate.Value.ToString("dd.MM.yyyy")} {StartTimeTb.Text}";
                if(DateTime.TryParse(startDate, out DateTime dateTimeStart))
                {
                    if (dateTimeStart > DateTime.Now)
                    {
                        var selectedClient = ClientCb.SelectedItem as Client;
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = selectedClient.ID,
                            ServiceID = service.ID,
                            StartTime = dateTimeStart,
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Запись добавлена!");
                        MyNavigation.NextPage(new PageComponent(new ServiceListPage(), "Список услуг"));
                    }
                    else
                    {
                        MessageBox.Show("Дата записи уже прошла!");
                    }
                }
                else
                {
                    MessageBox.Show("Время введено неверно!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void StartTimeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(StartTimeTb.Text.Length == 5)
            {
                if(DateTime.TryParse(StartTimeTb.Text, out DateTime startTime))
                {
                    int seconds = service.DurationInSeconds;
                    DateTime endTime = startTime.AddSeconds(seconds);
                    EndTimeTb.Text = endTime.ToShortTimeString();
                }
                else
                    EndTimeTb.Text = $"";
            }
        }
    }
}
