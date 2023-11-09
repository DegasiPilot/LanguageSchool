using LanguageSchool.Components;
using Microsoft.Win32;
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

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            DataContext = service;
            RefreshPhoto();
            PhotoUserContol.parentScript = this;
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*jpg|*jpg|*jpeg|*jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (App.db.Service.Any(x => x.Title == service.Title && (service.ID == 0 || x.ID != service.ID)))
            {
                errors.AppendLine("Такая услуга уже существует");
            }

            if (service.DurationInSeconds > 14400)
            {
                errors.AppendLine("Услуга дольше 4 часов");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                if (service.ID == 0)
                {
                    App.db.Service.Add(service);
                }
                App.db.SaveChanges();
                MyNavigation.BackPage();
            }
        }

        private void DiscountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*jpg|*jpg|*jpeg|*jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto()
                {
                    ServiceID = service.ID,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)
                });
                App.db.SaveChanges();
                RefreshPhoto();
            }
        }

        public void RefreshPhoto()
        {
            PhotoWp.Children.Clear();
            foreach (var photo in service.ServicePhoto)
            {
                PhotoWp.Children.Add(new PhotoUserContol(photo));
            }
            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream byteStream = new MemoryStream(service.MainImage);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = byteStream;
            bitmapImage.EndInit();
            MainImage.Source = bitmapImage;

        }
    }
}
