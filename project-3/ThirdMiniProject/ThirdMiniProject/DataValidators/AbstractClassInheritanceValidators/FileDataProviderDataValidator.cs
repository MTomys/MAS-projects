using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThirdMiniProject.DataValidators.AbstractClassInheritanceValidators
{
    public class FileDataProviderDataValidator
    {
        public static bool ValidateSource(string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                throw new ArgumentException($"Found empty string for {nameof(source)}");
            }

            return true;
        }
    }
}
