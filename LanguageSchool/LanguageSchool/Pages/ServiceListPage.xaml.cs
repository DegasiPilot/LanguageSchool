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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if(App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh_Filter(null,null);
        }

        private void Refresh_Filter(object sender, RoutedEventArgs e)
        {
            IEnumerable<Service> services = App.db.Service;
            switch (SortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    services = services.OrderBy(x => x.TotalCost);
                    break;
                case 2:
                    services = services.OrderByDescending(x => x.TotalCost);
                    break;
            }

            switch (DiscountFilterCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    services = services.Where(x => x.Discount >= 0 && x.Discount < 0.05);
                    break;
                case 2:
                    services = services.Where(x => x.Discount >= 0.05 && x.Discount < 0.15);
                    break;
                case 3:
                    services = services.Where(x => x.Discount >= 0.15 && x.Discount < 0.30);
                    break;
                case 4:
                    services = services.Where(x => x.Discount >= 0.30 && x.Discount < 0.70);
                    break;
                case 5:
                    services = services.Where(x => x.Discount >= 0.70 && x.Discount < 0.100);
                    break;
            }

            string searchText = SearchTb.Text.ToLower();
            if (searchText != "")
            {
                services = services.Where(x => x.Title.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText));
            }

            ServiceWrapPanel.Children.Clear();
            foreach (var service in services)
            {
                ServiceWrapPanel.Children.Add(
                    new ServiceUserControl(service)
                );
            }
            KolvoZapiseyTb.Text = services.Count() + " из " + App.db.Service.Count();
        }
    }
}
