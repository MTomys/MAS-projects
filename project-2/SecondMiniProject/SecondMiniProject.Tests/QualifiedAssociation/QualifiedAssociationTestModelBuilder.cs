using SecondMiniProject.Associations.QualifiedAssociation;
using SecondMiniProject.Associations.QualifiedAssociation.Impl;
using SecondMiniProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMiniProject.Tests.QualifiedAssociation;

public class QualifiedAssociationTestModelBuilder
{
    private static readonly int BookId = 1;
    private static readonly string BookName = "BookTestName";
    private static readonly string BookAuthorName = "BookTestAuthorName";
    private static readonly string BookIsbnNumber = "1234567890123";

    private static readonly string SecondBookIsbnNumber = "0987654321098";

    private static readonly int BookLibraryId = 1;
    private static readonly string BookLibraryName = "BookLibraryTestName";

    private static readonly IReferenceManager<Book, BookLibrary> ReferenceManager = new BookLibraryReferenceManagerImpl();

    public static Book CreateBook()
    {
        return new Book(BookId, BookName, BookAuthorName, BookIsbnNumber, ReferenceManager);
    }

    public static BookLibrary CreateBookLibrary()
    {
        return new BookLibrary(BookLibraryId, BookLibraryName);
    }

    public static Book CreateSecondBook()
    {
        return new Book(BookId + 1, $"Second{BookName}", $"Second{BookAuthorName}", SecondBookIsbnNumber, ReferenceManager);
    }

    public static BookLibrary CreateSecondBookLibrary()
    {
        return new BookLibrary(BookLibraryId + 1, $"Second{BookLibraryName}");
    }
}
