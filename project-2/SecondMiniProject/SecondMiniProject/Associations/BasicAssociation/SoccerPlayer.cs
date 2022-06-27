using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;
using SecondMiniProject.DataValidators;

namespace SecondMiniProject.Associations.BasicAssociation;

public class SoccerPlayer
{
    private int _id;
    private string _name;
    private SoccerTeam? _soccerTeam;
    private IReferenceManager<SoccerPlayer, SoccerTeam> _referenceManager;

    public SoccerPlayer(int id, string name, IReferenceManager<SoccerPlayer, SoccerTeam> referenceManager)
    {
        _id = id;
        if (SoccerPlayerDataValidator.ValidateSoccerPlayerName(name))
        {
            _name = name;
        }
        _referenceManager = referenceManager;
    }

    public int Id { get => _id; }
    public string Name 
    {
        get => _name;
        set
        {
            if (SoccerPlayerDataValidator.ValidateSoccerPlayerName(value))
            {
                _name = value;
            }
        }
    }
    public SoccerTeam SoccerTeam
    {
        get => _soccerTeam;

        set
        {
            if (_soccerTeam == value)
            {
                return;
            }
            if (value is null)
            {
                if (_soccerTeam is null)
                {
                    return;
                }
                else if (_soccerTeam is not null)
                {
                    _referenceManager.DeleteCurrentReference(this);
                    _soccerTeam = null;
                }
            }
            else if (value is not null)
            {
                if (_soccerTeam is null)
                {
                    _referenceManager.AddNewReference(this, value);
                    _soccerTeam = value;
                }
                else if (_soccerTeam is not null)
                {
                    _referenceManager.ReplaceCurrentReference(this, value);
                    _soccerTeam = value;
                }
            }

        }
    }

    public void JoinTeam(SoccerTeam soccerTeam)
    {
        ArgumentNullException.ThrowIfNull(soccerTeam);
        SoccerTeam = soccerTeam;
    }

    public void DisbandTeam()
    {
        SoccerTeam = null;
    }

    public override bool Equals(object? obj)
    {
        return obj is SoccerPlayer player &&
               _id == player._id &&
               _name == player._name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }

    public override string? ToString()
    {
        return $"SoccerPlayer: id \"{Id}\", name \"{Name}\", hashCode: \"{GetHashCode()}\"";
    }
}
