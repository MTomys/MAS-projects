using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;
namespace SecondMiniProject.Associations.AttributeAssociation.Impl;

public class CharacterReferenceManagerImpl : IReferenceManager<Auction, Character>
{
    public void AddNewReference(Auction auction, Character character)
    {
        character.Auctions.Add(auction);
    }

    public void DeleteCurrentReference(Auction auction)
    {
        auction.Seller.Auctions.Remove(auction);
    }

    public void DeleteCurrentReference(Auction auction, Character character)
    {
        throw new NotImplementedException();
    }

    public void ReplaceCurrentReference(Auction auction, Character character)
    {
        DeleteCurrentReference(auction);
        AddNewReference(auction, character);
    }
}
