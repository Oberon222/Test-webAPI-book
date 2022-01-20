using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data.ViewModels
{
  public class BookVM
  {
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
    public List<int> AuthorsId { get; set; }
  }

  public class BookWithAuthorsVM
  {
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }
    public bool IsRead { get; set; }

    [Required]
    public DateTime DateAdded { get; set; }
    public string Genre { get; set; }
    public string ImageURL { get; set; }

    [Required]
    public string PublisherName { get; set; }
    public List<string> AuthorsNames { get; set; }
  }
}


