using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data.Models
{
  public class Book
  {
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }
    public bool IsRead { get; set; }

    [Required]
    public DateTime DateAdded { get; set; }

    [Required]
    public string Genre { get; set; }
    public string ImageURL { get; set; }

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public List<Book_Author> Book_Authors { get; set; }
  }
}
