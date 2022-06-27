using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;
using SecondMiniProject.DataValidators;

namespace SecondMiniProject.Associations.BasicAssociation;

public class SoccerTeam
{
    private int _id;
    private string _name;
    private readonly ISet<SoccerPlayer> _soccerPlayers;

    public SoccerTeam(int id, string name)
    {
        _id = id;
        if (SoccerTeamDataValidator.ValidateSoccerTeamName(name))
        {
            _name = name;
        }
        _soccerPlayers = new HashSet<SoccerPlayer>();
    }

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public ISet<SoccerPlayer> SoccerPlayers { get => _soccerPlayers; }

    public void AddPlayer(SoccerPlayer soccerPlayer)
    {
        SoccerTeamDataValidator.ValidateSoccerPlayer(soccerPlayer);
        soccerPlayer.SoccerTeam = this;
    }

    public void RemovePlayer(SoccerPlayer soccerPlayer)
    {
        SoccerTeamDataValidator.ValidateSoccerPlayer(soccerPlayer);
        if (SoccerTeamDataValidator.CheckIfSoccerPlayerExistsInTeam(this, soccerPlayer))
        {
            soccerPlayer.SoccerTeam = null;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is SoccerTeam team &&
               _id == team._id &&
               _name == team._name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }
    public override string? ToString()
    {
        return $"SoccerTeam: id \"{Id}\", name \"{Name}\", hashCode: \"{GetHashCode()}\"";
    }

}
