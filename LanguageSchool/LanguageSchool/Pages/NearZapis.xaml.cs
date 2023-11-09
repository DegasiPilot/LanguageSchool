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
using System.Windows.Threading;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для NearZapis.xaml
    /// </summary>
    public partial class NearZapis : Page
    {
        public DateTime endTime;
        public NearZapis()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();

            endTime = DateTime.Now.AddDays(2);
            ZapisList.ItemsSource = App.db.ClientService.Where(x => x.StartTime > DateTime.Now &&
            x.StartTime <= endTime).OrderBy(x => x.StartTime).ToList();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            endTime = DateTime.Now.AddDays(2);
            ZapisList.ItemsSource = App.db.ClientService.Where(x => x.StartTime > DateTime.Now &&
            x.StartTime <= endTime).OrderBy(x => x.StartTime).ToList();
        }
    }
}
