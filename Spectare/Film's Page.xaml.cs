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
    /// Логика взаимодействия для Film_s_Page.xaml
    /// </summary>
    public partial class Film_s_Page : Window
    {
        DbMethods methods = new DbMethods();
        Film film { get; set; }
        public Film_s_Page(DbMethods _methods,Film _film)
        {
            InitializeComponent();
            methods = _methods;
            film = _film;
            FilmTitle.Text = film.Title;
            Description.Text = film.Description;
            string actors;
            foreach(var a in film.Actors)
            {
                Actors.Text += a.Name;
                if(a!=film.Actors.Last())
                    Actors.Text +=",";
            }
            string stringpath = film.PosterLink;
            Uri imageuri = new Uri(stringpath, UriKind.Relative);
            BitmapImage imagebitmap = new BitmapImage(imageuri);
            Poster.Source = imagebitmap;
        }

        private void AddtoFavourites_Click(object sender, RoutedEventArgs e)
        {
            methods.AddToFavorites(methods.User, film);
            AddtoFavourites.Visibility = Visibility.Collapsed;
            DeleteFromFavourites.Visibility = Visibility.Visible;
        }

        private void DeleteFromFavourites_Click(object sender, RoutedEventArgs e)
        {
            methods.RemoveFromFavorites(methods.User, film);
            DeleteFromFavourites.Visibility = Visibility.Collapsed;
            AddtoFavourites.Visibility = Visibility.Visible;
        }
    }
}
