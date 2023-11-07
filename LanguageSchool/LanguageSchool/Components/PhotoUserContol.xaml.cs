using LanguageSchool.Pages;
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
    /// Логика взаимодействия для PhotoUserContol.xaml
    /// </summary>
    public partial class PhotoUserContol : UserControl
    {
        ServicePhoto servicePhoto;
        public static AddEditServicePage parentScript;

        public PhotoUserContol(ServicePhoto servicePhoto)
        {
            InitializeComponent();
            this.servicePhoto = servicePhoto;
            DataContext = servicePhoto;
        }

        private void MakeMainBtn_Click(object sender, RoutedEventArgs e)
        {
            var buffer = servicePhoto.PhotoByte.ToArray();
            servicePhoto.PhotoByte = servicePhoto.Service.MainImage;
            servicePhoto.Service.MainImage = buffer;
            App.db.SaveChanges();
            parentScript.RefreshPhoto();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.ServicePhoto.Remove(servicePhoto);
            App.db.SaveChanges();
            parentScript.RefreshPhoto();
        }
    }
}
