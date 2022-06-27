using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMiniProject.Associations.AttributeAssociation;

public class AuctionHouse
{
    private readonly int _id;
    private string _name;
    private readonly HashSet<Auction> _auctions;

    public AuctionHouse(int id, string name)
    {
        _id = id;
        _name = name;
        _auctions = new HashSet<Auction>();
    }

    public int Id { get => _id; }
    public string Name { get => _name; set => _name = value; }
    public ISet<Auction> Auctions { get => _auctions; }

    public void CreateAuction(Character character, Auction auction)
    {
        ArgumentNullException.ThrowIfNull(character);
        ArgumentNullException.ThrowIfNull(auction);
        auction.Seller = character;
        auction.AuctionHouse = this;
    }

    public void RemoveAuction(Auction auction)
    {
        ArgumentNullException.ThrowIfNull(auction);
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
        return obj is AuctionHouse house &&
               _name == house._name;
    }
    public override string? ToString()
    {
        return $"AuctionHouseID: {this.Id}, AuctionHouseName: {this.Name}, AuctionHouseHashCode: {this.GetHashCode()}";
    }
}
