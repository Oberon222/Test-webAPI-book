using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data.Models
{
  public class Author
  {
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    public List<Book_Author> Book_Authors { get; set; }
  }
}
