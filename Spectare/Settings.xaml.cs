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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        DbMethods methods = new DbMethods();
        public Settings (DbMethods _methods)
        {
            InitializeComponent();
            methods = _methods;
        }

        private User _curUser;
        public Settings(User curUser)
        {
            InitializeComponent();
            _curUser = curUser;
            TBName.Text = _curUser.Name;
            TBEmail.Text = _curUser.Email;
            TBPassword.Text = _curUser.Password;
        }

        
        private void TBName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "Enter new name")
                TBName.Text = "";
        }
        private void TBEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBEmail.Text == "Enter new email")
                TBEmail.Text = "";
        }
        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "Enter new password")
                TBPassword.Text = "";
        }


        private void TBName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "")
                TBName.Text = "Enter new name";
        }
        private void TBEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TBEmail.Text == "")
                TBEmail.Text = "Enter new email";
        }
        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "")
                TBPassword.Text = "Enter new password";
        }
            private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuwindow = new MenuWindow(methods);
            menuwindow.Show();
            this.Close();
        }

        private void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
        private void Editing(object sender, RoutedEventArgs e)
        {

        }
    }

    }

