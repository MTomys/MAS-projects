using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;
using SecondMiniProject.Associations.AttributeAssociation.Impl;
using SecondMiniProject.DataValidators;
namespace SecondMiniProject.Associations.AttributeAssociation;

public class Auction
{
    private readonly int _id;
    private readonly int _quantity;
    private readonly double _price;
    private readonly string _itemName;
    private Character? _seller;
    private AuctionHouse? _auctionHouse;
    private readonly IReferenceManager<Auction, Character> _characterReferenceManager;
    private readonly IReferenceManager<Auction, AuctionHouse> _auctionHouseReferenceManager;

    public Auction(int id, int quantity, double price, string itemName, IReferenceManager<Auction, Character> characterReferenceManager, IReferenceManager<Auction, AuctionHouse> auctionHouseReferenceManager)
    {
        _id = id;

        if (AuctionDataValidator.ValidateQuantity(quantity))
        {
            _quantity = quantity;
        }

        if (AuctionDataValidator.ValidatePrice(price))
        {
            _price = price;
        }

        if (AuctionDataValidator.ValidateItemName(itemName))
        {
            _itemName = itemName;
        }
        _characterReferenceManager = characterReferenceManager;
        _auctionHouseReferenceManager = auctionHouseReferenceManager;
    }

    public int Id { get => _id; }
    public int Quantity { get => _quantity; }
    public double Price { get => _price; }
    public string ItemName { get => _itemName; }

    public Character Seller
    {
        get => _seller;
        set
        {
            if (this._seller == value)
            {
                return;
            }
            if (value is null)
            {
                if (_seller is null)
                {
                    return;
                }
                else if (_seller is not null)
                {
                    _characterReferenceManager.DeleteCurrentReference(this);
                    _seller = null;
                }
                return;
            }
            else if (value is not null)
            {
                if (_seller is null)
                {
                    _characterReferenceManager.AddNewReference(this, value);
                    _seller = value;
                }
                else if (_seller is not null)
                {
                    _characterReferenceManager.ReplaceCurrentReference(this, value);
                    _seller = value;
                }
                return;
            }
        }
    }
    public AuctionHouse AuctionHouse
    {
        get => _auctionHouse;
        set
        {
            if (this._auctionHouse is null && value is null)
            {
                return;
            }
            if (this._auctionHouse == value)
            {
                return;
            }
            if (value is null)
            {
                if (_auctionHouse is null)
                {
                    return;
                }
                else if (_auctionHouse is not null)
                {
                    _auctionHouseReferenceManager.DeleteCurrentReference(this);
                    _auctionHouse = null;
                }
                return;
            }
            else if (value is not null)
            {
                if (_auctionHouse is null)
                {
                    _auctionHouseReferenceManager.AddNewReference(this, value);
                    _auctionHouse = value;
                }
                else if (_auctionHouse is not null)
                {
                    _auctionHouseReferenceManager.ReplaceCurrentReference(this, value);
                    _auctionHouse = value;
                }
                return;
            }
        }
    }
    
    public override string? ToString()
    {
        return $"\" AuctionID: {this._id}, AuctionItemName: {this._itemName}, AuctionHashCode: {this.GetHashCode()}\n\tAuctionSeller: {this._seller},\n\tAuctionAH: {this._auctionHouse}.\"";
    }

    public override bool Equals(object? obj)
    {
        return obj is Auction auction &&
               _id == auction._id &&
               _itemName == auction._itemName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _itemName);
    }
}
