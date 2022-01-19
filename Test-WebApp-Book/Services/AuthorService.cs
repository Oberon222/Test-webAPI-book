using System;
using System.Collections.Generic;
using System.Linq;
using Test_WebApp_Book.Data;
using Test_WebApp_Book.Data.Models;
using Test_WebApp_Book.Data.ViewModels;
using Test_WebApp_Book.Interfaces;

namespace Test_WebApp_Book.Services
{
  public class AuthorService : IAuthorService
  {
    private readonly AppDbContext _context;
    public AuthorService(AppDbContext context)
    {
      _context = context;
    }

    public Author AddAuthor(AuthorVM authorVM)
    {
      var _author = new Author()
      {
        FullName = authorVM.FullName
      };
      _context.Authors.Add(_author);
      _context.SaveChanges();

      return _author;
    }

    public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
    {
      var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
      {
        FullName = n.FullName,
        BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
      }).FirstOrDefault();

      return _author;
    }

    public List<Author> GetAllAuthors()
    {
      var _allAuthors = _context.Authors.ToList();
      return _allAuthors;
    }

    public Author GetAuhtorById(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);

    public Author UpdateAuthorById(int authorId, AuthorVM authorVM)
    {
      var _author = _context.Authors.FirstOrDefault(a => a.Id == authorId);
      if(_author != null)
      {
        _author.FullName = authorVM.FullName;
        _context.SaveChanges();
      }
      return _author;
    }

    public void DeleteAuthor(int id)
    {
      var _author = _context.Authors.FirstOrDefault(a => a.Id == id);
      if(_author != null)
      {
        _context.Authors.Remove(_author);
        _context.SaveChanges();
      }
      else
      {
        throw new Exception($"The author with id: {id} does not found");
      }
    }
  }
}
