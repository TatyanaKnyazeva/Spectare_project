﻿using System;
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
using System.Data;

namespace Spectare
{
    /// <summary>
    /// Логика взаимодействия для FavouritesWindow.xaml
    /// </summary>
    public partial class FavouritesWindow : Window
    {
        DbMethods methods = new DbMethods();

        public FavouritesWindow(DbMethods _methods)
        {
            InitializeComponent();

            methods = _methods;

            dataGridFavourites.ItemsSource = methods.User.FavFilms;
        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridFavourites.SelectedItems.Count != 0)
            {
                Film film = (Film)dataGridFavourites.SelectedItems[0];
                methods.RemoveFromFavorites(methods.User, film);
                dataGridFavourites.ItemsSource = null;
                dataGridFavourites.ItemsSource = methods.User.FavFilms;
            }
            else
            {
                MessageBox.Show("Выберите фильм, который надо удалить");
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            var menuwindow = new MenuWindow(methods);
            menuwindow.Show();
            Close();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Film film = (Film)dataGridFavourites.SelectedItems[0];
            var favouriteswindow = new Film_s_Page(methods,film);
            favouriteswindow.Show();
            Close();
        }
    }
}
