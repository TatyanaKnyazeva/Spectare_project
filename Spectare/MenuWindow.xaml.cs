﻿using Spectare.Classes;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FavouritesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void helperButton_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            helper.Show();
            Close();
        }
        private void GoToHelper(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper(methods);
            helper.Show();
            Close();
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            game.Show();
            Close();
        }
    }
}
