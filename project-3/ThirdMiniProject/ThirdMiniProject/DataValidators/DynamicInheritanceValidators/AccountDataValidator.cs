using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.DataValidators.DynamicInheritanceValidators
{
    public class AccountDataValidator
    {
        public static bool ValidateCommonStrings(string someString)
        {
            if (String.IsNullOrEmpty(someString))
            {
                throw new ArgumentException($"Argument is null or empty: {nameof(someString)}");
            }
            return true;
        }
    }
}
