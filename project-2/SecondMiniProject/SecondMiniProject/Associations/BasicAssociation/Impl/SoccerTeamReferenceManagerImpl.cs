using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;

namespace SecondMiniProject.Associations.BasicAssociation.Impl;

public class SoccerTeamReferenceManagerImpl : IReferenceManager<SoccerPlayer, SoccerTeam>
{
    public void AddNewReference(SoccerPlayer soccerPlayer, SoccerTeam soccerTeam)
    {
        soccerTeam.SoccerPlayers.Add(soccerPlayer);
    }

    public void DeleteCurrentReference(SoccerPlayer soccerPlayer)
    {
        soccerPlayer.SoccerTeam.SoccerPlayers.Remove(soccerPlayer);
    }

    public void DeleteCurrentReference(SoccerPlayer soccerPlayer, SoccerTeam soccerTeam)
    {
        throw new NotImplementedException();
    }

    public void ReplaceCurrentReference(SoccerPlayer soccerPlayer, SoccerTeam soccerTeam)
    {
        DeleteCurrentReference(soccerPlayer);
        AddNewReference(soccerPlayer, soccerTeam);
    }
}
