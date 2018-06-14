using Spectare.Classes;
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
using System.Windows.Shapes;

namespace Spectare
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        DbMethods methods = new DbMethods();
        public MenuWindow(DbMethods _methods)
        {
            InitializeComponent();
            methods = _methods;
        }

        private void ButtonFavorites_Click(object sender, RoutedEventArgs e)
        {
            var favouriteswindow = new FavouritesWindow(methods.User.FavFilms);
            favouriteswindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            Close();
        }
        private void GoToHelper(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            helper.Show();
            Close();
        }

    }
}
