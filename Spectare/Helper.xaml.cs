using System;
using System.Collections.Generic;
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
        public Helper()
        {
            InitializeComponent();
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
        //Generation of answer

        static string Ans(string q)
        {
            string tr = ")(:^=!@#$%&*';:><.,/?",
                ans = "";
            q = q.ToLower();
            q = Trim(q, tr.ToCharArray());
            string[] baza = File.ReadAllLines("../../1");
            //Searching
            for (int i = 0; i < baza.Length; i += 2)
            {
                if (q == baza[i])
                {
                    ans = baza[i + 1];
                    break;
                }

            }
            return ans;
        }
        public static void In()
        {
            while (true)
            {
                Console.Write("");
                string q = Console.ReadLine();
                Console.WriteLine("" + Ans(q) + "\n");
            }
        }
    }
}
