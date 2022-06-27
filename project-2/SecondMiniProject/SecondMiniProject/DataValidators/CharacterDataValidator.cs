using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Constants;

namespace SecondMiniProject.DataValidators;

public class CharacterDataValidator
{
    public static bool ValidateCharacterName(string characterName)
    {
        if (String.IsNullOrEmpty(characterName) || String.IsNullOrWhiteSpace(characterName))
        {
            throw new ArgumentException(CommonMessages.CommonErrorMessages.GetInvalidCharacterNameMessage(characterName));
        }
        return true;
    }

    public static bool ValidateCharacterGold(double gold)
    {
        if (gold <= 0)
        {
            throw new ArgumentException(CommonMessages.CommonErrorMessages.GetInvalidCharacterGoldMessage(gold));
        }
        return true;
    }

    public static bool ValidateCharacterLevel(int level)
    {
        if (level <= 0 || level > Constants.CharacterConstants.MaxLevel)
        {
            throw new ArgumentException(CommonMessages.CommonErrorMessages.GetInvalidCharacterLevelMessage(level));
        }
        return true;
    }
}
