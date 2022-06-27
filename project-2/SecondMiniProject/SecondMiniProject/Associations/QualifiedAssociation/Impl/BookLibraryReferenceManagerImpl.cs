using SecondMiniProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.CommonMessages;

namespace SecondMiniProject.Associations.QualifiedAssociation.Impl;

public class BookLibraryReferenceManagerImpl : IReferenceManager<Book, BookLibrary>
{
    public void AddNewReference(Book book, BookLibrary bookLibrary)
    {
        if (bookLibrary.Books.ContainsKey(book.IsbnNumber))
        {
            throw new InvalidOperationException(CommonErrorMessages.GetBookLibraryBookKeyIsAlreadyPresentMessage(book.IsbnNumber));
        }
        bookLibrary.Books.Add(book.IsbnNumber, book);
    }

    public void DeleteCurrentReference(Book book)
    {
        book.BookLibrary.Books.Remove(book.IsbnNumber);
    }

    public void DeleteCurrentReference(Book book, BookLibrary bookLibrary)
    {
        throw new NotImplementedException();
    }

    public void ReplaceCurrentReference(Book book, BookLibrary bookLibrary)
    {
        DeleteCurrentReference(book);
        AddNewReference(book, bookLibrary);
    }
}
