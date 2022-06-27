using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMiniProject.MyUtils;

public class HelperFunctions
{
    public static bool IsDigitsOnly(string text)
    {
        return text.All(c => (c >= '0' && c <= '9') );
    }
}
