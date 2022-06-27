using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.BasicAssociation;
using SecondMiniProject.Associations.BasicAssociation.Impl;
using SecondMiniProject.Interfaces;

namespace SecondMiniProject.Tests.BasicAssociation;

public class BasicAssociationTestModelBuilder
{
    private static readonly int SoccerPlayerId = 1;
    private static readonly string SoccerPlayerName = "TestSoccerPlayerName";

    private static readonly int SoccerTeamId = 1;
    private static readonly string SoccerTeamName = "TestSoccerTeamName";

    private static readonly IReferenceManager<SoccerPlayer, SoccerTeam> ReferenceManager = new SoccerTeamReferenceManagerImpl();

    public static SoccerPlayer CreateSoccerPlayer()
    {
        return new SoccerPlayer(SoccerPlayerId, SoccerPlayerName, ReferenceManager);
    }

    public static SoccerPlayer CreateSecondSoccerPlayer()
    {
        return new SoccerPlayer(SoccerPlayerId + 1, $"Second{SoccerPlayerName}", ReferenceManager);
    }

    public static SoccerTeam CreateSoccerTeam()
    {
        return new SoccerTeam(SoccerTeamId, SoccerTeamName);
    }

    public static SoccerTeam CreateSecondSoccerTeam()
    {
        return new SoccerTeam(SoccerTeamId + 1, $"Second{SoccerTeamName}");
    }
}
