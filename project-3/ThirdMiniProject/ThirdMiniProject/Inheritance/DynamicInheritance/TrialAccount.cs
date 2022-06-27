using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.DynamicInheritanceValidators;

namespace ThirdMiniProject.Inheritance.DynamicInheritance
{
    public class TrialAccount : Account
    {
        private string _paymentAddress;

        public TrialAccount(Account oldAccount, string paymentAddress) : base(oldAccount.Login, oldAccount.Password, oldAccount.Email)
        {
            PaymentAdress = paymentAddress;
        }

        public string PaymentAdress 
        { 
            get => _paymentAddress;
            set => _paymentAddress = AccountDataValidator.ValidateCommonStrings(value) ? value : "";
        }
    }
}
