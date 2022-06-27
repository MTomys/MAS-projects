using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.DataValidators;

namespace SecondMiniProject.Associations.QualifiedAssociation;

public class BookLibrary
{
    private readonly int _id;
    private string _name;
    private readonly IDictionary<string, Book> _books;

    public BookLibrary(int id, string name)
    {
        _id = id;

        if (BookLibraryDataValidator.ValidateBookLibraryName(name))
        {
            _name = name;
        }

        _books = new Dictionary<string, Book>();
    }

    public int Id { get => _id; }
    public string Name
    {
        get => _name;

        set
        {
            if (BookLibraryDataValidator.ValidateBookLibraryName(value))
            {
                _name = value;
            }
        }
    }

    public IDictionary<string, Book> Books { get => _books; }

    public void AddBook(Book book)
    {
        if (BookLibraryDataValidator.ValidateBookLibraryBook(book))
        {
            book.BookLibrary = this;
        }
    }
    public void RemoveBook(Book book)
    {
        if (BookLibraryDataValidator.ValidateBookLibraryBook(book))
        {
            book.BookLibrary = null;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is BookLibrary library &&
               _id == library._id &&
               _name == library._name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }
}
