using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.DynamicInheritanceValidators;

namespace ThirdMiniProject.Inheritance.DynamicInheritance
{
    public class Account
    {
        private string _login;
        private string _password;
        private string _email;

        public Account(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        public string Login { get => _login; set => _login = (AccountDataValidator.ValidateCommonStrings(value)) ? value : ""; }
        public string Password { get => _password; set => _password = (AccountDataValidator.ValidateCommonStrings(value)) ? value : ""; }
        public string Email { get => _email; set => _email = (AccountDataValidator.ValidateCommonStrings(value)) ? value : ""; }

    }
}
