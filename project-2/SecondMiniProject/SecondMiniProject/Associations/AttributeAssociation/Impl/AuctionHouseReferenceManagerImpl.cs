using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;
using System.Collections.Immutable;
namespace SecondMiniProject.Associations.AttributeAssociation.Impl;

public class AuctionHouseReferenceManagerImpl : IReferenceManager<Auction, AuctionHouse>
{
    public void AddNewReference(Auction auction, AuctionHouse auctionHouse)
    {
        auctionHouse.Auctions.Add(auction);
    }

    public void DeleteCurrentReference(Auction auction)
    {
        auction.AuctionHouse.Auctions.Remove(auction);
    }

    public void DeleteCurrentReference(Auction auction, AuctionHouse auctionHouse)
    {
        throw new NotImplementedException();
    }

    public void ReplaceCurrentReference(Auction auction, AuctionHouse auctionHouse)
    {
        DeleteCurrentReference(auction);
        AddNewReference(auction, auctionHouse);
    }
}
