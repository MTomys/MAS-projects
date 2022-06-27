using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.CommonMessages;

namespace SecondMiniProject.DataValidators;

public class SoccerPlayerDataValidator
{
    public static bool ValidateSoccerPlayerName(string name)
    {
        if (String.IsNullOrEmpty(name))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidSoccerPlayerNameMessage(name));
        }
        return true;
    }
}
