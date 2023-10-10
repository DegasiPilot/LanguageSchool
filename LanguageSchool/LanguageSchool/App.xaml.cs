using LanguageSchool.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LanguageSchool_Entities db = new LanguageSchool_Entities();
        public static bool IsAdmin = false;
    }
}
