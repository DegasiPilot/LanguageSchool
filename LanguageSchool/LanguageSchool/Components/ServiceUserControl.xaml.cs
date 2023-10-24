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

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {
        Service service;

        public ServiceUserControl(Service _service)
        {
            InitializeComponent();
            service = _service;
            ServiceImage.Source = GetImageSource(service.MainImage);
            TitleTb.Text = service.Title;
            CostTb.Text = service.Cost.ToString("0");
            CostTimeTb.Text = service.CostTime;
            DiscountTb.Text = service.TextDiscount;
            CostTb.Visibility = service.CostVisiblity;
            UserControlGrid.Background = service.DicountBrush;
            if(App.IsAdmin == false)
            {
                RedactBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }

        private BitmapImage GetImageSource(byte[] byteImage)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                if (service.MainImage != null)
                {
                    MemoryStream byteStream = new MemoryStream(byteImage);
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = byteStream;
                    bitmapImage.EndInit();
                }
                else
                {
                    bitmapImage = new BitmapImage(new Uri(@"\Images\school_logo.png",UriKind.Relative));
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            return bitmapImage;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(service.ClientService != null)
            {
                MessageBox.Show("Удаление запрещено");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
            }
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            MyNavigation.NextPage(new PageComponent(new AddEditServicePage(service), "Редактировать услугу"));
        }
    }
}