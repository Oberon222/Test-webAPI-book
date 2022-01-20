using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data.ViewModels
{
  public class AuthorVM
  {
    [Required]
    public string FullName { get; set; }
  }

 public class AuthorWithBooksVM
  {
    [Required]
    public string FullName { get; set; }
    public List<string> BookTitles { get; set; }
  }
}
