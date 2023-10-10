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

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {
        public ServiceUserControl(Image image, string title, decimal cost, string costTime, string discount, Visibility costVisibility)
        {
            InitializeComponent();
            ServiceImage = image;
            TitleTb.Text = title;
            CostTb.Text = cost.ToString("0");
            CostTimeTb.Text = costTime;
            DiscountTb.Text = discount;
            CostTb.Visibility = costVisibility;
            if(App.IsAdmin == false)
            {
                RedactBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }
    }
}
