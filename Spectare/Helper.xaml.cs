using Spectare.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для Helper.xaml
    /// </summary>
    public partial class Helper : Window
    {
        DbMethods methods = new DbMethods();
        public Helper(DbMethods _methods)
        {
            InitializeComponent();
            methods = _methods;
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuwindow = new MenuWindow(methods);
            menuwindow.Show();
            this.Close();
        }
        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {

           string q = textBoxNumber.Text;
            TB2.Text = Ans(q);
            textBoxNumber.Clear();
                
            
        }
        //Deleting letters
        static string Trim(string str, char[] chars)
        {
            string strA = str; //Копирование строки
            for (int i = 0; i < chars.Length; i++) //Удаление строки
            {
                strA = strA.Replace(char.ToString(chars[i]), "");
            }
            return strA;
        }
        static string Ans(string q)
        {
            string tr = ")(:^=!@#$%&*';:><.,/?",
                ans = "";
            q = q.ToLower();
            q = Trim(q, tr.ToCharArray());
            string[] baza = File.ReadAllLines("../../1");
            ans = "Are you sure? Please, be more concentrate, I don`t understand this.";
            for (int i = 0; i < baza.Length; i += 2)
            {
               if (q == baza[i])
                {
                    ans = baza[i + 1];
                }
            }
            return ans;
        }
    }
}
