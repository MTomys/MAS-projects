using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.BasicAssociation;

namespace SecondMiniProject.CommonMessages;

public class CommonErrorMessages
{
    public static string GetArgumentInvalidMessage(string argumentName)
    {
        return $"Invalid argument found for argument: \"{argumentName}\".";
    }

    public static string GetInvalidAuctionQuantityMessage(int quantity)
    {
        return $"Invalid capacity found: (capacity: {quantity}).";
    }

    public static string GetInvalidAuctionPriceMessage(double price)
    {
        return $"Invalid price found: (price: {price}).";
    }

    public static string GetInvalidItemNameMessage(string itemName)
    {
        return $"Invalid item name found: (itemName: {itemName}).";
    }

    public static string GetInvalidCharacterNameMessage(string characterName)
    {
        return $"Invalid character name found: (characterName: {characterName}).";
    }

    public static string GetInvalidCharacterGoldMessage(double gold)
    {
        return $"Invalid character gold found: (characterGold: {gold}).";
    }

    public static string GetInvalidCharacterLevelMessage(int level)
    {
        return $"Invalid character level found: (characterLevel: {level}).";
    }

    public static string GetInvalidSoccerPlayerNameMessage(string name)
    {
        return $"Invalid soccer player name found: (soccerPlayerName: {name})";
    }

    public static string GetInvalidSoccerTeamNameMessage(string name)
    {
        return $"Invalid soccer team name found: (soccerTeamName: {name})";
    }

    public static string GetSoccerPlayerNotPresentInTeamMessage(SoccerPlayer soccerPlayer)
    {
        return $"Soccer player not present within the SoccerTeamPlayers collection (soccerPlayer: {soccerPlayer})";
    }
    
    public static string GetInvalidStorageUnitNameMessage(string name)
    {
        return $"Invalid storage unit name found: (storageUnitName: {name}).";
    }

    public static string GetInvalidStorageUnitCapacityMessage(double capacity)
    {
        return $"Invalid storage unit capacity found: (storageUnitCapacity: {capacity}).";
    }

    public static string GetInvalidStorageUnitStorageHouseMessage()
    {
        return $"Invalid storage unit storage house (can not be null).";
    }

    public static string GetInvalidStorageUnitStorageHouseHasDuplicateMessage()
    {
        return $"Invalid storage house passed, already contains duplicate in it's collection.";
    }

    public static string GetStorageUnitIsUnsusableMessage()
    {
        return $"After initial dereference, this unit's \"StorageHouse\" property setter is unusable, do not use any further references to this object instance.";
    }

    public static string GetInvalidStorageHouseNameMessage(string name)
    {
        return $"Invalid storage house name found: (storageHouseName: {name}).";
    }

    public static string GetInvalidStorageHouseLocationMessage(string location)
    {
        return $"Invalid storage house location found: (storageHouseLocation: {location}).";
    }

    public static string GetInvalidStorageHouseStorageUnitMessage()
    {
        return $"Storage unit can not be null !";
    }

    public static string GetInvalidBookNameMessage(string bookName)
    {
        return $"Invalid book name found: (bookName: {bookName}).";
    }

    public static string GetInvalidBookAuthorNameMessage(string authorName)
    {
        return $"Invalid book author name found: (bookAuthor: {authorName}).";

    }

    public static string GetInvalidBookIsbnNumberMessage(string isbnNumber)
    {
        return $"Invalid book isbnNumber found (isbnNumber: {isbnNumber}) (Note: ISBN must be 13 digits only).";
    }

    public static string GetInvalidBookLibraryNameMessage(string bookLibraryName)
    {
        return $"Invalid book library name found: (bookLibraryName: {bookLibraryName})";
    }

    public static string GetBookLibraryBookKeyIsAlreadyPresentMessage(string isbnNumber)
    {
        return $"The dictionary already contains this key. (isbnNumber: {isbnNumber}).";
    }

    public static string GetBookLibraryInvalidBookMessage()
    {
        return $"Book can not be null!";
    }
}
