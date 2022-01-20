using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data.Models
{
  public class Publisher
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public List<Book> Books { get; set; }
  }
}
