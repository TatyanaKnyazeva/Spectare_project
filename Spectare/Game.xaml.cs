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
using System.Windows.Threading;

namespace Spectare
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        DbMethods methods = new DbMethods();
        public Game(DbMethods _methods)
        {
            InitializeComponent();
            methods = _methods;
            
        }

        

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
