using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMiniProject.DataValidators;

public class AuctionDataValidator
{
    public static bool ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException(CommonMessages.CommonErrorMessages.GetInvalidAuctionQuantityMessage(quantity));
        }
        return true;
    }

    public static bool ValidatePrice(double price)
    {
        if (price <= 0)
        {
            throw new ArgumentException(CommonMessages.CommonErrorMessages.GetInvalidAuctionPriceMessage(price));
        }
        return true;
    }

    public static bool ValidateItemName(string itemName)
    {
        if (String.IsNullOrEmpty(itemName) || String.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException(CommonMessages.CommonErrorMessages.GetInvalidItemNameMessage(itemName));
        }
        return true;
    }
}
