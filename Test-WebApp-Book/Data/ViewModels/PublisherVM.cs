using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApp_Book.Data.ViewModels;

namespace Test_WebApp_Book.Data.ViewModels
{
  public class PublisherVM
  {
    [Required]
    public string Name { get; set; }
  }
}

public class PublisherWithBooksAndAuthorsVM
{
  [Required]
  public string Name { get; set; }
  public List<BookAuthorVM> BookAuthors { get; set; }

}
