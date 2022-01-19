using System.Collections.Generic;
using Test_WebApp_Book.Data.Models;
using Test_WebApp_Book.Data.ViewModels;

namespace Test_WebApp_Book.Interfaces
{
  public interface IBookService
  {
    void AddBookWithAuthors(BookVM book);
    List<Book> GetAllBooks();
    BookWithAuthorsVM GetGookById(int bookId);
    Book UpdateBookById(int id, BookVM bookVM);
    void DeleteBookById(int id);
  }
}
