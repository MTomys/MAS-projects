using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.DataValidators;
using SecondMiniProject.Interfaces;
namespace SecondMiniProject.Associations.AttributeAssociation;

public class Character
{
    private readonly int _id;
    private string _name;
    private double _gold;
    private int _level;
    private readonly ISet<Auction> _auctions;

    public Character(int id, string name, double gold, int level)
    {
        _id = id;

        if (CharacterDataValidator.ValidateCharacterName(name))
        {
            _name = name;
        }

        if (CharacterDataValidator.ValidateCharacterGold(gold))
        {
            _gold = gold;
        }

        if (CharacterDataValidator.ValidateCharacterLevel(level))
        {
            _level = level;
        }

        _auctions = new HashSet<Auction>();
    }

    public int Id { get => _id; }
    public string Name
    {
        get => _name;
        set
        {
            if (CharacterDataValidator.ValidateCharacterName(value))
            {
                _name = value;
            }
        }
    }
    public double Gold
    {
        get => _gold;
        set
        {
            if (CharacterDataValidator.ValidateCharacterGold(value))
            {
                _gold = value;
            }
        }
    }
    public int Level
    {
        get => _level;
        set
        {
            if (CharacterDataValidator.ValidateCharacterLevel(value))
            {
                _level = value;
            }
        }
    }
    public ISet<Auction> Auctions { get => _auctions; }

    public void CreateAuction(Auction auction, AuctionHouse auctionHouse)
    {
        auction.Seller = this;
        auction.AuctionHouse = auctionHouse;
    }

    public void DeleteAuction(Auction auction)
    {
        auction.Seller = null;
        auction.AuctionHouse = null;
    }

    public void PrintAuctions()
    {
        foreach (var auction in _auctions)
        {
            Console.WriteLine($"AuctionID: {auction.Id}, AuctionName: {auction.ItemName}, AuctionSeller: {auction.Seller}, AuctionAH: {auction.AuctionHouse}, AuctionHashCode: {auction.GetHashCode()}. ");
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }
    public override bool Equals(object? obj)
    {
        return obj is Character character &&
               _name == character._name;
    }
    public override string? ToString()
    {
        return $"CharacterID: {this.Id}, CharacterName: {this._name}, CharacterLevel: {this.Level} CharacterHashCode: {this.GetHashCode()}";
    }
}
