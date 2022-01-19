using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApp_Book.Data.ViewModels;

namespace Test_WebApp_Book.Data.ViewModels
{
  public class PublisherVM
  {
    public string Name { get; set; }
  }
}

public class PublisherWithBooksAndAuthorsVM
{
  public string Name { get; set; }
  public List<BookAuthorVM> BookAuthors { get; set; }

}
