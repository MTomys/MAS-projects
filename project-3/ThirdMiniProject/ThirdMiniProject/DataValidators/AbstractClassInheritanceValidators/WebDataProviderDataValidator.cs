using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThirdMiniProject.DataValidators.AbstractClassInheritanceValidators
{
    public class WebDataProviderDataValidator
    {
        public static bool ValidateSource(string source)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));

            if (!Regex.IsMatch(source, Constants.Regexes.Regexes.WebUrlPattern))
            {
                throw new ArgumentException($"Invalid web url name for: {nameof(source)}");
            }

            return true;
        }
    }
}

