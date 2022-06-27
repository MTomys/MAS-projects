using SecondMiniProject.Associations.QualifiedAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SecondMiniProject.Tests.QualifiedAssociation;

public class QualifiedAssociationTests
{
    private static readonly string TestIsbnNumber = "1234567890111";

    [Fact]
    public void BookLibrary_AddBook_SimpleAddingOfABook()
    {
        // Arrange
        Book book = QualifiedAssociationTestModelBuilder.CreateBook();
        BookLibrary bookLibrary = QualifiedAssociationTestModelBuilder.CreateBookLibrary();

        // Act
        bookLibrary.AddBook(book);

        // Assert
        Assert.Equal(bookLibrary, book.BookLibrary);

        Assert.Equal(book, bookLibrary.Books[book.IsbnNumber]);
        Assert.Contains<string>(book.IsbnNumber, bookLibrary.Books.Keys);
    }

    [Fact]
    public void BookLibrary_AddBook_TryAddingBookWithKeyAlreadyPresent()
    {
        // Arrange
        Book book = QualifiedAssociationTestModelBuilder.CreateBook();
        Book secondBook = QualifiedAssociationTestModelBuilder.CreateBook();
        BookLibrary bookLibrary = QualifiedAssociationTestModelBuilder.CreateBookLibrary();

        // Act
        bookLibrary.AddBook(book);
        Action action = () => bookLibrary.AddBook(secondBook);

        // Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(action);

        Assert.Equal(CommonMessages.CommonErrorMessages.GetBookLibraryBookKeyIsAlreadyPresentMessage(secondBook.IsbnNumber), exception.Message);

        Assert.Equal(bookLibrary, book.BookLibrary);

        Assert.Equal(book, bookLibrary.Books[book.IsbnNumber]);
        Assert.Contains<string>(book.IsbnNumber, bookLibrary.Books.Keys);
    }

    [Fact]
    public void BookLibrary_AddBook_ReplacingBookLibraryReferenceInTargetBook()
    {
        // Arrange
        Book book = QualifiedAssociationTestModelBuilder.CreateBook();
        BookLibrary bookLibrary = QualifiedAssociationTestModelBuilder.CreateBookLibrary();
        BookLibrary secondBookLibrary = QualifiedAssociationTestModelBuilder.CreateSecondBookLibrary();

        // Act
        bookLibrary.AddBook(book);
        secondBookLibrary.AddBook(book);

        // Assert
        Assert.NotEqual(bookLibrary, book.BookLibrary);

        Assert.DoesNotContain<string>(book.IsbnNumber, bookLibrary.Books.Keys);

        Assert.Equal(secondBookLibrary, book.BookLibrary);

        Assert.Equal(book, secondBookLibrary.Books[book.IsbnNumber]);
        Assert.Contains<string>(book.IsbnNumber, secondBookLibrary.Books.Keys);
    }

    [Fact]
    public void BookLibrary_RemoveBook_SimpleBookRemoval()
    {
        // Arrange
        Book book = QualifiedAssociationTestModelBuilder.CreateBook();
        BookLibrary bookLibrary = QualifiedAssociationTestModelBuilder.CreateBookLibrary();

        // Act
        bookLibrary.AddBook(book);
        bookLibrary.RemoveBook(book);

        // Assert
        Assert.NotEqual(bookLibrary, book.BookLibrary);

        Assert.DoesNotContain<string>(book.IsbnNumber, bookLibrary.Books.Keys);
        Assert.Equal(0, bookLibrary.Books.Count);
    }

    [Fact]
    public void Book_SetIsbnNumber_SetIsbnNumberWhenBookLibraryReferenceNull()
    {
        // Arrange
        Book book = QualifiedAssociationTestModelBuilder.CreateBook();

        // Act
        book.IsbnNumber = TestIsbnNumber;

        // Assert
        Assert.Equal(TestIsbnNumber, book.IsbnNumber);
    }

    [Fact]
    public void Book_SetIsbnNumber_SetIsbnNumberWhenBookLibraryReferenceNotNull()
    {
        // Arrange
        Book book = QualifiedAssociationTestModelBuilder.CreateBook();
        Book secondBook = QualifiedAssociationTestModelBuilder.CreateBook();
        BookLibrary bookLibrary = QualifiedAssociationTestModelBuilder.CreateBookLibrary();

        // Act
        bookLibrary.AddBook(book);
        book.IsbnNumber = TestIsbnNumber;

        // Assert
        Assert.Equal(TestIsbnNumber, book.IsbnNumber);

        Assert.Equal(bookLibrary, book.BookLibrary);

        Assert.Contains<string>(book.IsbnNumber, bookLibrary.Books.Keys);
        Assert.Contains<string>(TestIsbnNumber, bookLibrary.Books.Keys);
        Assert.Equal(book, bookLibrary.Books[TestIsbnNumber]);

        Assert.Equal(1, bookLibrary.Books.Count);
    }
}
