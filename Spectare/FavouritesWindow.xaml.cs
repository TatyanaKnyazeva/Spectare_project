using System;
using System.Collections.Generic;
using Spectare.Classes;
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
    /// Логика взаимодействия для FavouritesWindow.xaml
    /// </summary>
    public partial class FavouritesWindow : Window
    {
        List<Film> films = new List<Film>();

        public FavouritesWindow(DbMethods _methods)
        {
            InitializeComponent();

            films = _methods.User.FavFilms;

            dataGridFavourites.ItemsSource = films;
        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
