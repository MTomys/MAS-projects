using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SecondMiniProject.Tests.AttributeAssociation;
using SecondMiniProject.Associations.AttributeAssociation;

namespace SecondMiniProject.Tests.AttributeAssociation;

public class AttributeAssociationTests
{
    // Character Tests
    [Fact]
    public void Character_CreateAuction_SimpleReferenceCreation()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        character.CreateAuction(auction, auctionHouse);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Equal(auction.Seller, character);

        Assert.Contains<Auction>(auction, auctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, auctionHouse);

        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);
    }

    [Fact]
    public void Character_CreateAuction_TryCreatingMultipleEqualAuctions()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        character.CreateAuction(auction, auctionHouse);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Equal(auction.Seller, character);

        Assert.Contains<Auction>(auction, auctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, auctionHouse);

        Assert.Equal(1, character.Auctions.Count);
        Assert.Equal(1, auctionHouse.Auctions.Count);


        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);
    }

    [Fact]
    public void Character_DeleteAuction_SimpleReferenceDeletion()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        character.CreateAuction(auction, auctionHouse);
        character.DeleteAuction(auction);

        // Assert
        Assert.DoesNotContain<Auction>(auction, character.Auctions);
        Assert.NotEqual(auction.Seller, character);

        Assert.DoesNotContain<Auction>(auction, auctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, auctionHouse);

        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);
    }

    [Fact]
    public void Character_SetAuction_MultipleAuctionsCreation()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        character.CreateAuction(auction, auctionHouse);
        secondCharacter.CreateAuction(secondAuction, secondAuctionHouse);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Equal(auction.Seller, character);

        Assert.Contains<Auction>(auction, auctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, auctionHouse);

        Assert.Contains<Auction>(secondAuction, secondCharacter.Auctions);
        Assert.Equal(secondAuction.Seller, secondCharacter);
        
        Assert.Contains<Auction>(secondAuction, secondAuctionHouse.Auctions);
        Assert.Equal(secondAuction.AuctionHouse, secondAuctionHouse);
        
        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);

        Assert.DoesNotContain<Auction>(secondAuction, auctionHouse.Auctions);
        Assert.NotEqual(secondAuction.Seller, character);

        Assert.DoesNotContain<Auction>(secondAuction, character.Auctions);
        Assert.NotEqual(secondAuction.AuctionHouse, auctionHouse);

    }

    [Fact] 
    public void Character_SetAuction_AuctionReferenceReassignmentToAnotherCharacter()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        character.CreateAuction(auction, auctionHouse);
        secondCharacter.CreateAuction(auction, auctionHouse);

        // Assert
        Assert.DoesNotContain<Auction>(auction, character.Auctions);
        Assert.NotEqual(auction.Seller, character);

        Assert.Contains<Auction>(auction, secondCharacter.Auctions);
        Assert.Equal(auction.Seller, secondCharacter);

        Assert.Contains<Auction>(auction, auctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, auctionHouse);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);
    }

    [Fact] 
    public void Character_SetAuction_AuctionReferenceReassignmentToAnotherAuctionHouse()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        character.CreateAuction(auction, auctionHouse);
        character.CreateAuction(auction, secondAuctionHouse);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Equal(auction.Seller, character);

        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, auctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, auctionHouse);

        Assert.Contains<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, secondAuctionHouse);
    }



    // AuctionHouse Tests
    [Fact]
    public void AuctionHouse_CreateAuction_SimpleReferenceCreation()
    {
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        auctionHouse.CreateAuction(character, auction);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Contains<Auction>(auction, auctionHouse.Auctions);

        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);

    }

    [Fact]
    public void AuctionHouse_RemoveAuction_SimpleReferenceDeletion()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        auctionHouse.CreateAuction(character, auction);
        auctionHouse.RemoveAuction(auction);

        // Assert
        Assert.DoesNotContain<Auction>(auction, character.Auctions);
        Assert.NotEqual(auction.Seller, character);

        Assert.DoesNotContain<Auction>(auction, auctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, auctionHouse);

        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);
    }

    [Fact]
    public void AuctionHouse_SetAuction_SimpleReferenceReassignmentToAnotherAuctionHouse()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        auctionHouse.CreateAuction(character, auction);
        secondAuctionHouse.CreateAuction(character, auction);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Equal(auction.Seller, character);

        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.NotEqual(auction.Seller, secondCharacter);

        Assert.DoesNotContain<Auction>(auction, auctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, auctionHouse);

        Assert.Contains<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, secondAuctionHouse);

    }


    [Fact]
    public void AuctionHouse_SetAuction_SimpleReferenceReassignmentToAnotherCharacter()
    {
        // Arrange
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        auctionHouse.CreateAuction(character, auction);
        auctionHouse.CreateAuction(secondCharacter, auction);

        // Assert
        Assert.DoesNotContain<Auction>(auction, character.Auctions);
        Assert.NotEqual(auction.Seller, character);

        Assert.Contains<Auction>(auction, secondCharacter.Auctions);
        Assert.Equal(auction.Seller, secondCharacter);

        Assert.Contains<Auction>(auction, auctionHouse.Auctions);
        Assert.Equal(auction.AuctionHouse, auctionHouse);

        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);
        Assert.NotEqual(auction.AuctionHouse, secondAuctionHouse);

    }

    [Fact]
    public void AuctionHouse_CreateAuction_TryCreatingMultipleEqualAuctions()
    {
        Auction auction = AttributeAssociationTestModelBuilder.GetAuction();
        Auction secondAuction = AttributeAssociationTestModelBuilder.GetSecondAuction();

        Character character = AttributeAssociationTestModelBuilder.GetCharacter();
        Character secondCharacter = AttributeAssociationTestModelBuilder.GetSecondCharacter();

        AuctionHouse auctionHouse = AttributeAssociationTestModelBuilder.GetAuctionHouse();
        AuctionHouse secondAuctionHouse = AttributeAssociationTestModelBuilder.GetSecondAuctionHouse();

        // Act
        auctionHouse.CreateAuction(character, auction);
        auctionHouse.CreateAuction(character, auction);

        // Assert
        Assert.Contains<Auction>(auction, character.Auctions);
        Assert.Contains<Auction>(auction, auctionHouse.Auctions);

        Assert.Equal(1, auctionHouse.Auctions.Count);
        Assert.Equal(1, character.Auctions.Count);
;
        Assert.DoesNotContain<Auction>(auction, secondCharacter.Auctions);
        Assert.DoesNotContain<Auction>(auction, secondAuctionHouse.Auctions);

    }
}
