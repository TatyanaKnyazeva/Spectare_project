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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbMethods methods = new DbMethods();
        public MainWindow()
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
            if (textbox1.Text.Trim().Equals(string.Empty))
            {
                textbox1.Text = "Full Name";
                textbox1.Foreground = Brushes.Silver;
                textbox1.GotFocus += TextBox_GotFocus;
            }
            if (textbox2.Text.Trim().Equals(string.Empty))
            {
                textbox2.Text = "Email";
                textbox2.Foreground = Brushes.Silver;
                textbox2.GotFocus += TextBox_GotFocus;
            }
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            var loginwindow = new LoginWindow();
            loginwindow.Show();
            Close();
        }

        private void textbox3_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox3.Visibility = System.Windows.Visibility.Collapsed;
            passwordbox.Visibility = System.Windows.Visibility.Visible;
            passwordbox.Focus();
        }

        private void passwordbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(passwordbox.Password))
            {
                textbox3.Visibility = System.Windows.Visibility.Visible;
                passwordbox.Visibility = System.Windows.Visibility.Collapsed;
                textbox3.Text = "Password";
                textbox3.Foreground = Brushes.Silver;
                textbox3.GotFocus += TextBox_GotFocus;
            }
        }

        private void signupbutton_Click(object sender, RoutedEventArgs e)
        {
            var loginwindow = new LoginWindow();
            if((textbox1.Text=="Full Name" && textbox2.Text=="Email" && textbox3.Text == "Password")||
                (textbox1.Text=="" && textbox2.Text == "Email" && textbox3.Text == "Password") ||
                (textbox2.Text=="" && textbox1.Text == "Full Name" && textbox3.Text == "Password")||
                (passwordbox.Password=="" && textbox1.Text == "Full Name" && textbox2.Text == "Email" ))
            {
                fields.Visibility = Visibility.Visible;
            }
            if ((textbox1.Text != "" && textbox2.Text == "Email" && textbox3.Text == "Password") ||
                (textbox2.Text != "" && textbox1.Text == "Full Name" && textbox3.Text == "Password") ||
                (passwordbox.Password != "" && textbox1.Text == "Full Name" && textbox2.Text == "Email"))
            {
                fields.Visibility = Visibility.Collapsed;
            }
            if ((!textbox2.Text.EndsWith("@email.ru") || !textbox2.Text.EndsWith("@gmail.com") || !textbox2.Text.EndsWith("@edu.hse.ru"))
                && (textbox2.Text!="Email"))
            {
                
                textblockemail.Visibility = System.Windows.Visibility.Visible;
                textblockemail.Foreground = Brushes.Silver;
                textblockemail.Text = "This isn't a valid email address";
                loginwindow.IsEnabled = false;
                
            }
            if (textbox2.Text.EndsWith("@mail.ru") || textbox2.Text.EndsWith("@gmail.com") || textbox2.Text.EndsWith("@edu.hse.ru"))
            {
                
                textblockemail.Visibility = System.Windows.Visibility.Collapsed;
            }
                

            int passwordcharacters = passwordbox.Password.Length;

            if ((passwordcharacters <8) && (textbox3.Text!="Password"))
            {
                textblockpassw.Visibility = System.Windows.Visibility.Visible;
                textblockpassw.Foreground = Brushes.Silver;
                textblockpassw.Text = "password should contain at least 8 charaters";
                loginwindow.IsEnabled = false;
            }

            if (passwordcharacters >= 8)
            {
                
                textblockpassw.Visibility = System.Windows.Visibility.Collapsed;
            }
                

            if (passwordcharacters >= 8 && (textbox2.Text.Contains("@mail.ru") || textbox2.Text.Contains("@gmail.com")))
            {
                string name = textbox1.Text;
                string email = textbox2.Text;
                string password = passwordbox.Password;
                try
                {
                    methods.Registration(name, email, password);
                    MessageBox.Show("Your account has been created");
                }
                catch
                {
                    MessageBox.Show("An error occured trying to save new user");
                }
            }
        }

    }
}
