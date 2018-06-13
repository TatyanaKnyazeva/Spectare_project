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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DbMethods methods = new DbMethods();
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_GotFocus;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailtextbox.Text.Trim().Equals(string.Empty))
            {
                emailtextbox.Text = "Email";
                emailtextbox.Foreground = Brushes.Silver;
                emailtextbox.GotFocus += TextBox_GotFocus;
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
            if (String.IsNullOrWhiteSpace(passwordbox.Password))
            {
                passwordtextbox.Visibility = System.Windows.Visibility.Visible;
                passwordbox.Visibility = System.Windows.Visibility.Collapsed;
                passwordtextbox.Text = "Password(at least 8 characters)";
                passwordtextbox.Foreground = Brushes.Silver;
                passwordtextbox.GotFocus += TextBox_GotFocus;
            }
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            var mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (methods.Authorization(emailtextbox.Text, passwordbox.Password))
            {
                var menuwindow = new MenuWindow(methods);
                menuwindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Incorrect login/password");
            }
        }
    }
}
