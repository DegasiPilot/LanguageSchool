using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LanguageSchool.Components
{
    public static class MyNavigation
    {
        static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;

        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }

        public static void BackPage()
        {
            if(components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components.Last());
            }
        }

        public static void ClearStory()
        {
            components.Clear();
            mainWindow.BackBtn.Visibility = Visibility.Hidden;
        }

        private static void Update(PageComponent pageComponent)
        {
            mainWindow.TitleTb.Text = pageComponent.Title;
            mainWindow.BackBtn.Visibility =
                components.Count() > 1 ?
                Visibility.Visible : Visibility.Hidden;
            mainWindow.MainFrame.Navigate(pageComponent.Page);
        }
    }

    public class PageComponent
    {
        public Page Page { get; set; }
        public string Title { get;set; }

        public PageComponent(Page page, string title)
        {
            Page = page;
            Title = title;
        }
    }
}
