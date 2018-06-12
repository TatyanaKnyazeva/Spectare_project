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
        public Settings()
        {
            InitializeComponent();
        }

        //private User _curUser;
        //    public Settings (User curUser)
        //    {
        //        InitializeComponent();
        //        _curUser = curUser;
        //        textBoxName.Text = _curUser.Name;
        //        textBoxSurname.Text = _curUser.Surname;
        //        textBoxEmail.Text = _curUser.Email;
        //    }

            private void textBoxSurname_LostFocus(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrEmpty(textBoxSurname.Text.Trim()))
                    fakeTextBoxSurname.Visibility = System.Windows.Visibility.Visible;
            }

            private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
                    fakeTextBoxName.Visibility = System.Windows.Visibility.Visible;
            }

            private void textBoxEmail_LostFocus(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrEmpty(textBoxEmail.Text.Trim()))
                    fakeTextBoxEmail.Visibility = System.Windows.Visibility.Visible;
            }

            private void fakeTextBoxName_GotFocus(object sender, RoutedEventArgs e)
            {
                fakeTextBoxName.Visibility = System.Windows.Visibility.Collapsed;
                textBoxName.Focus();
            }

            private void fakeTextBoxSurname_GotFocus(object sender, RoutedEventArgs e)
            {
                fakeTextBoxSurname.Visibility = System.Windows.Visibility.Collapsed;
                textBoxSurname.Focus();
            }

            private void fakeTextBoxEmail_GotFocus(object sender, RoutedEventArgs e)
            {
                fakeTextBoxEmail.Visibility = System.Windows.Visibility.Collapsed;
                textBoxEmail.Focus();
            }

            //private void Button_Submit_Click(object sender, RoutedEventArgs e)
            //{
            //    emptySurnameMessage.Visibility = System.Windows.Visibility.Collapsed;
            //    emptyEmailMessage.Visibility = System.Windows.Visibility.Collapsed;
            //    emptyNameMessage.Visibility = System.Windows.Visibility.Collapsed;
            //    existingEmailMessage.Visibility = System.Windows.Visibility.Collapsed;
            //    bool emptyName = string.IsNullOrEmpty(textBoxName.Text.Trim());
            //    bool emptySurname = string.IsNullOrEmpty(textBoxSurname.Text.Trim());
            //    bool emptyEmail = string.IsNullOrEmpty(textBoxEmail.Text.Trim());
            //    if (emptyEmail || emptyEmail || emptySurname)
            //    {
            //        if (emptySurname)
            //            emptySurnameMessage.Visibility = System.Windows.Visibility.Visible;
            //        if (emptyName)
            //            emptyNameMessage.Visibility = System.Windows.Visibility.Visible;
            //        if (emptyEmail)
            //            emptyEmailMessage.Visibility = System.Windows.Visibility.Visible;
            //    }
            //    else
            //    {
            //        if (Repository.CanAddUser(textBoxEmail.Text) || _curUser.Email == textBoxEmail.Text)
            //        {
            //            _curUser.Name = textBoxName.Text;
            //            _curUser.Surname = textBoxSurname.Text;
            //            _curUser.Email = textBoxEmail.Text;
            //            Repository.RepositorySave();
            //            MainWindow mainWindow = new MainWindow(_curUser);
            //            mainWindow.Show();
            //            Close();
            //        }
            //        else
            //        {
            //            existingEmailMessage.Visibility = System.Windows.Visibility.Visible;
            //        }
            //    }
            //}

            //private void Button_Back_Click(object sender, RoutedEventArgs e)
            //{
            //    MainWindow mainWindow = new MainWindow(_curUser);
            //    mainWindow.Show();
            //    Close();
            //}

            private void Button_LogOut_Click(object sender, RoutedEventArgs e)
            {
                Registration registerWindow = new Registration();
                registerWindow.Show();
                Close();
            }

        private void GoToHelper(object sender, RoutedEventArgs e)
        {
          Helper helperWindow = new Helper();
            helperWindow.Show();
            Close();
        }

        //private void Button_DeleteAccount_Click(object sender, RoutedEventArgs e)
        //{
        //    ConfirmationWindow confirm = new ConfirmationWindow();
        //    confirm.ShowDialog();
        //    if (confirm.DialogResult == true)
        //    {
        //        Repository.Users.Remove(Repository.Users.SingleOrDefault(u => u.Email == _curUser.Email));
        //        Repository.RepositorySave();
        //        LoginWindow loginWindow = new LoginWindow();
        //        loginWindow.Show();
        //        Close();
        //    }
        //}

        //private void Button_PasswordChange_Click(object sender, RoutedEventArgs e)
        //{
        //    var passwordChangeWindow = new PasswordChangeWindow(_curUser);
        //    passwordChangeWindow.ShowDialog();
        //}
    }

    }

