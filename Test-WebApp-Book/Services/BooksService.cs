using System;
using System.Collections.Generic;
using System.Linq;
using Test_WebApp_Book.Data;
using Test_WebApp_Book.Data.Models;
using Test_WebApp_Book.Data.ViewModels;
using Test_WebApp_Book.Interfaces;

namespace Test_WebApp_Book.Services
{
  public class BooksService : IBookService
  {
    private readonly AppDbContext _context;
    public BooksService(AppDbContext context)
    {
      _context = context;
    }

    public void AddBookWithAuthors(BookVM book)
    {
      var _book = new Book()
      {
        Title=book.Title,
        Description=book.Description,
        IsRead=book.IsRead,
        DateAdded=book.DateAdded,
        Genre=book.Genre,
        ImageURL=book.ImageURL,
        PublisherId = book.PublisherId
      };
      _context.Books.Add(_book);
      _context.SaveChanges();

      foreach (var id in book.AuthorsId)
      {
        var _book_author = new Book_Author()
        {
          BookId = _book.Id,
          AuthorId = id
        };
        _context.Book_Authors.Add(_book_author);
        _context.SaveChanges();
      }      
    }

    public List<Book> GetAllBooks() => _context.Books.ToList();

    public BookWithAuthorsVM GetGookById(int bookId)
    {
      var _bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(b => new BookWithAuthorsVM()
      {
        Title = b.Title,
        Description = b.Description,
        IsRead = b.IsRead,
        DateAdded = b.DateAdded,
        Genre = b.Genre,
        ImageURL = b.ImageURL,
        PublisherName = b.Publisher.Name,
        AuthorsNames = b.Book_Authors.Select(n => n.Author.FullName).ToList()
      }).FirstOrDefault();

      return _bookWithAuthors;
    }

    public Book UpdateBookById(int id, BookVM bookVM)
    {
      var _book = _context.Books.FirstOrDefault(n => n.Id == id);
      if(_book != null)
      {
        _book.Title = bookVM.Title;
        _book.Description = bookVM.Description;
        _book.IsRead = bookVM.IsRead;
        _book.Genre = bookVM.Genre;
        _book.ImageURL = bookVM.ImageURL;
        _context.SaveChanges();          
      }
      return _book;
    }
       

   public void DeleteBookById(int id)
    {
      var _book = _context.Books.FirstOrDefault(b => b.Id == id);
      if(_book != null)
      {
        _context.Books.Remove(_book);
        _context.SaveChanges();
      }
      else
      {
        throw new Exception($"Book with id: {id} not found");
      }
    }
  }
}
