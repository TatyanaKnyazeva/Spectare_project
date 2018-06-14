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

        private void NameChange_Click(object sender, RoutedEventArgs e)
        {
            if (TBName.Text != "Enter new name" && TBName.Text != "")
                methods.ChangeName(TBName.Text);
            else
                MessageBox.Show("enter new name");
        }

        private void EmailChange_Click(object sender, RoutedEventArgs e)
        {
            if (TBEmail.Text != "Enter new email" && TBEmail.Text != "")
                methods.ChangeEmail(TBEmail.Text);
            else
                MessageBox.Show("Enter new email");
             
        }

        private void PasswordChange_Click(object sender, RoutedEventArgs e)
        {
            if(passwordtextbox.Text!="enter new password" && passwordtextbox.Text!="" && passwordbox.Password != "")
            {
                methods.Changepassword(passwordbox.Password)
            }
            else
            {
                MessageBox.Show("Enter password");
            }
        }

        private void passwordtextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordtextbox.Visibility = System.Windows.Visibility.Collapsed;
            passwordbox.Visibility = System.Windows.Visibility.Visible;
            passwordbox.Focus();
        }

        private void passwordbox_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordtextbox.Visibility = System.Windows.Visibility.Collapsed;
            passwordbox.Visibility = System.Windows.Visibility.Visible;
            passwordbox.Focus();
        }
    }
}

