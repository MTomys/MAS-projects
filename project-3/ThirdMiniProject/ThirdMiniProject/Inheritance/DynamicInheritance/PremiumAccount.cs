using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.DynamicInheritanceValidators;

namespace ThirdMiniProject.Inheritance.DynamicInheritance
{
    public class PremiumAccount : Account
    {
        private readonly ISet<string> _contacts;
        private string _paymentAddress;

        public PremiumAccount(Account oldAccount, string paymentAddress) : base(oldAccount.Login, oldAccount.Password, oldAccount.Email)
        {
            PaymentAddress = paymentAddress;
            _contacts = new HashSet<string>();
        }

        public ISet<string> Contacts { get => new HashSet<string>(_contacts); }

        public string PaymentAddress
        {
            get => _paymentAddress;
            set => _paymentAddress = AccountDataValidator.ValidateCommonStrings(value) ? value : "";
        }

        public void AddContact(string contactName) 
        {
            _contacts.Add(contactName);
        }

    }
}
