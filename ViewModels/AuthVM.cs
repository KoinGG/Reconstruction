using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Реконструирование.Help;
using Реконструирование.ViewModels;
//using Реконструирование.Views;

namespace Реконструирование.ViewModels
{
    public class AuthVM : BaseVM
    {
        private RelayCommand _loginCommand;
        private string _login;
        public static int UserID;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                    (_loginCommand = new RelayCommand((x) =>
                    {
                        var password = (x as PasswordBox).Password;
                        var login = _login;                        
                        var user = Helper.GetContext().Users.SingleOrDefault(x => x.Login == login && x.Password == password);
                        UserID = user.UserId;
                        if (user != null)
                        {
                            //Window Window = new Window();
                            App.Current.MainWindow.Close();
                           // Window.Show();
                        }
                    }, (x) =>
                    {
                        var passwordBox = x as PasswordBox;
                        if (passwordBox == null)
                        {
                            return false;
                        }

                        string password = passwordBox.Password;
                        return string.IsNullOrEmpty(_login) == false
                            && string.IsNullOrEmpty(password) == false;
                    }));
            }
        }
    }
}
