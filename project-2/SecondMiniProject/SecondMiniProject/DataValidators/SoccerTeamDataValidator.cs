using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.CommonMessages;
using SecondMiniProject.Associations.BasicAssociation;

namespace SecondMiniProject.DataValidators;

public class SoccerTeamDataValidator
{
    public static bool ValidateSoccerTeamName(string name)
    {
        if (String.IsNullOrEmpty(name))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidSoccerTeamNameMessage(name));
        }
        return true;
    }

    public static bool ValidateSoccerPlayer(SoccerPlayer soccerPlayer)
    {
        ArgumentNullException.ThrowIfNull(soccerPlayer);
        return true;
    }

    public static bool CheckIfSoccerPlayerExistsInTeam(SoccerTeam soccerTeam, SoccerPlayer soccerPlayer)
    {
        if (!soccerTeam.SoccerPlayers.Contains(soccerPlayer))
        {
            throw new ArgumentException(CommonErrorMessages.GetSoccerPlayerNotPresentInTeamMessage(soccerPlayer));
        }
        return true;
    }
}
