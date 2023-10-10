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
            var services = App.db.Service.ToList();
            foreach(var service in services)
            {
                ServiceWrapPanel.Children.Add(
                    new ServiceUserControl(
                    new Image(),
                    service.Title,
                    service.Cost,
                    service.CostTime,
                    service.TextDiscount,
                    service.CostVisiblity
                    )
                ) ;
            }
        }
    }
}
