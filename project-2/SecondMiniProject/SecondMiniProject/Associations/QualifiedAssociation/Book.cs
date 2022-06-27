using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;
using SecondMiniProject.DataValidators;
using SecondMiniProject.Associations.QualifiedAssociation.Impl;

namespace SecondMiniProject.Associations.QualifiedAssociation;

public class Book
{
    private readonly int _id;
    private string _name;
    private string _authorName;
    // For simplicity we go with 13 digit version only
    private string _isbnNumber;
    private IReferenceManager<Book, BookLibrary> _referenceManager;
    private BookLibrary? _bookLibrary;

    public Book(int id, string name, string authorName, string isbnNumber, IReferenceManager<Book, BookLibrary> referenceManager)
    {
        _id = id;
        if (BookDataValidator.ValidateBookName(name))
        {
            _name = name;
        }
        if (BookDataValidator.ValidateBookAuthorName(authorName))
        {
            _authorName = authorName;
        }
        if (BookDataValidator.ValidateBookIsbnNumber(isbnNumber))
        {
            _isbnNumber = isbnNumber;
        }
        _referenceManager = referenceManager;
    }

    public int Id { get => _id; }
    public string Name
    {
        get => _name;

        set
        {
            if (BookDataValidator.ValidateBookName(value))
            {
                _name = value;
            }
        }
    }
    public string AuthorName
    {
        get => _authorName;

        set
        {
            if (BookDataValidator.ValidateBookAuthorName(value))
            {
                _authorName = value;
            }
        }
    }
    public string IsbnNumber
    {
        get => _isbnNumber;

        set
        {
            if (BookDataValidator.ValidateBookIsbnNumber(value))
            {
                if (_bookLibrary is null)
                {
                    _isbnNumber = value;
                }
                else if (_bookLibrary is not null)
                {
                    BookLibrary tmpLibrary = _bookLibrary;
                    _referenceManager.DeleteCurrentReference(this);
                    _isbnNumber = value;
                    _referenceManager.AddNewReference(this, tmpLibrary);
                }
            }
        }
    }
    public BookLibrary BookLibrary
    {
        get => _bookLibrary;

        set
        {
            if (_bookLibrary == value)
            {
                return;
            }

            if (value is null)
            {
                if (_bookLibrary is null)
                {
                    return;
                }
                else if (_bookLibrary is not null)
                {
                    _referenceManager.DeleteCurrentReference(this);
                    _bookLibrary = null;
                }
            }
            else if (value is not null)
            {
                if (_bookLibrary is null)
                {
                    _referenceManager.AddNewReference(this, value);
                    _bookLibrary = value;
                }
                else if (_bookLibrary is not null)
                {
                    _referenceManager.ReplaceCurrentReference(this, value);
                    _bookLibrary = value;
                }
            }
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is Book book &&
               _isbnNumber == book._isbnNumber;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_isbnNumber);
    }
}
