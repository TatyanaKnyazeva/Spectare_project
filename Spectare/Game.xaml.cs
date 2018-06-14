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
using System.Windows.Threading;

namespace Spectare
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        List<Film> films = new List<Film>();

        DbMethods methods = new DbMethods();
        public Game(DbMethods _methods)
        {
            InitializeComponent();
            methods = _methods;

            films = methods.GetAllFilms();
            Film film = new Film();
            film = films[0];
            string stringpath = film.PhotoLink1;
            Uri imageuri = new Uri(stringpath, UriKind.Relative);
            BitmapImage imagebitmap = new BitmapImage(imageuri);
            FilmImage.Source = imagebitmap;
        }

        

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Film f = new Film();
            if (Answer.Text == films[0].Title)
            {
                f = films[0];
                films.Remove(f);
                if (films == null)
                {
                    MessageBox.Show("Вы победили! Поздравляем!!!");
                    MenuWindow menuwindow = new MenuWindow(methods);
                    menuwindow.Show();
                    Close();
                }
                else
                {
                    f = films[0];
                    string stringpath = f.PhotoLink1;
                    Uri imageuri = new Uri(stringpath, UriKind.Relative);
                    BitmapImage imagebitmap = new BitmapImage(imageuri);
                    FilmImage.Source = imagebitmap;
                }
            }
            else
            {

            }
        }
    }
}
