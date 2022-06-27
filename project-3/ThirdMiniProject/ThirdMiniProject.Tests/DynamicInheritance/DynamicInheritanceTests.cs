using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.DynamicInheritance;
using Xunit;

namespace ThirdMiniProject.Tests.DynamicInheritance
{
    public class DynamicInheritanceTests
    {

        [Fact]
        public void Account_TestIfAccountsAreSublcassOfParent()
        {
            // Arrange
            Account account = new Account("login", "password", "email@email.com");
            Account secondAccount = new Account("login1", "password1", "email1@email.com");

            // Act
            TrialAccount trialAccount = new TrialAccount(account, "039u489012h3b0f9");
            PremiumAccount premiumAccount = new PremiumAccount(secondAccount, "seurngaun48909a4");

            // Assert
            Assert.Equal(account.Login, trialAccount.Login);
            Assert.Equal(account.Password, trialAccount.Password);
            Assert.Equal(account.Email, trialAccount.Email);

            Assert.Equal(secondAccount.Login, premiumAccount.Login);
            Assert.Equal(secondAccount.Password, premiumAccount.Password);
            Assert.Equal(secondAccount.Email, premiumAccount.Email);

            Assert.IsAssignableFrom<Account>(trialAccount);
            Assert.IsType<TrialAccount>(trialAccount);

            Assert.IsAssignableFrom<Account>(premiumAccount);
            Assert.IsType<PremiumAccount>(premiumAccount);
        }
    }
}
