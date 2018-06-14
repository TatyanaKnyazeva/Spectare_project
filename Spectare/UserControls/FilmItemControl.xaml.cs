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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spectare
{
    /// <summary>
    /// Логика взаимодействия для FilmItemControl.xaml
    /// </summary>
    public partial class FilmItemControl : UserControl
    {
        DbMethods methods = new DbMethods();
        public FilmItemControl()
        {
            InitializeComponent();
        }

        private void imagebutton_Click(object sender, RoutedEventArgs e)
        {
           Film film = methods.GetAllFilms().FirstOrDefault(f => f.Title == FilmTitle.Text);
           Film_s_Page filmpage = new Film_s_Page(methods, film);
           filmpage.Show();
        }
    }
}
