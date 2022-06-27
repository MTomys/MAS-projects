using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.AttributeAssociation;
using SecondMiniProject.Associations.AttributeAssociation.Impl;
using SecondMiniProject.Interfaces;

namespace SecondMiniProject.Tests.AttributeAssociation;

public class AttributeAssociationTestModelBuilder
{
    private static readonly int ItemId = 1;
    private static readonly int ItemQuantity = 1;
    private static readonly double ItemPrice = 5;
    private static readonly string ItemName = "TestItemName";

    private static readonly int CharacterId = 1;
    private static readonly string CharacterName = "TestCharacterName";
    private static readonly double CharacterGold = 123;
    private static readonly int CharacterLevel = 60;

    private static readonly int AuctionHouseId = 1;
    private static readonly string AuctionHouseName = "TestAuctionHouseName";

    private static readonly IReferenceManager<Auction, Character> CharacterReferenceManager = new CharacterReferenceManagerImpl();
    private static readonly IReferenceManager<Auction, AuctionHouse> AuctionHouseReferenceManager = new AuctionHouseReferenceManagerImpl();
    
    public static Auction GetAuction()
    {
        return new Auction(ItemId, ItemQuantity, ItemPrice, ItemName, CharacterReferenceManager, AuctionHouseReferenceManager);
    }

    public static Auction GetSecondAuction()
    {
        return new Auction(ItemId + 1, ItemQuantity + 1, ItemPrice + 20, $"Second{CharacterName}", CharacterReferenceManager, AuctionHouseReferenceManager);
    }

    public static Character GetCharacter()
    {
        return new Character(CharacterId, CharacterName, CharacterGold, CharacterLevel);
    }

    public static Character GetSecondCharacter()
    {
        return new Character(CharacterId + 1, $"Second{CharacterName}", CharacterGold + 123, CharacterLevel - 1);
    }

    public static AuctionHouse GetAuctionHouse()
    {
        return new AuctionHouse(AuctionHouseId, AuctionHouseName);
    }

    public static AuctionHouse GetSecondAuctionHouse()
    {
        return new AuctionHouse(AuctionHouseId + 1, $"Second{AuctionHouseName}");
    }
}
