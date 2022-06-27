using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.CommonMessages;
using SecondMiniProject.MyUtils;

namespace SecondMiniProject.DataValidators;

public class BookDataValidator
{
    public static bool ValidateBookName(string bookName) 
    {
        if (String.IsNullOrEmpty(bookName))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidBookNameMessage(bookName));
        }
        return true;
    }

    public static bool ValidateBookAuthorName(string authorName)
    {
        if (String.IsNullOrEmpty(authorName))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidBookAuthorNameMessage(authorName));
        }
        return true;
    }

    public static bool ValidateBookIsbnNumber(string isbnNumber)
    {
        if (String.IsNullOrEmpty(isbnNumber) || (isbnNumber.Length != 13) || (HelperFunctions.IsDigitsOnly(isbnNumber) == false))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidBookIsbnNumberMessage(isbnNumber));
        }
        return true;
    }
}
