using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data.ViewModels
{
  public class BookAuthorVM
  {
    [Required]
    public string BookName { get; set; }
    public List<string> BookAuthors { get; set; }
  }
}
