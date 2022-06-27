using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.QualifiedAssociation;
using SecondMiniProject.CommonMessages;

namespace SecondMiniProject.DataValidators;

public class BookLibraryDataValidator
{
    public static bool ValidateBookLibraryName(string bookLibraryName)
    {
        if (String.IsNullOrEmpty(bookLibraryName))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidBookLibraryNameMessage(bookLibraryName));
        }
        return true;
    }

    public static bool ValidateBookLibraryBook(Book book)
    {
        ArgumentNullException.ThrowIfNull(book, CommonErrorMessages.GetBookLibraryInvalidBookMessage());
        return true;
    }
}
