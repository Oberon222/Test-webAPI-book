using System.Collections.Generic;
using Test_WebApp_Book.Data.Models;
using Test_WebApp_Book.Data.ViewModels;

namespace Test_WebApp_Book.Interfaces
{
  public interface IAuthorService
  {
    Author AddAuthor(AuthorVM authorVM);
    AuthorWithBooksVM GetAuthorWithBooks(int authorId);
    List<Author> GetAllAuthors();
    Author GetAuhtorById(int id);
    Author UpdateAuthorById(int authorId, AuthorVM authorVM);
    void DeleteAuthor(int id);

  }
}
