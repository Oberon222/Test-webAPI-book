using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Test_WebApp_Book.Data.ViewModels;
using Test_WebApp_Book.Services;

namespace Test_WebApp_Book.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly BooksService _booksService;
    public BooksController(BooksService booksService)
    {
      _booksService = booksService;
    }

    [HttpPost("add-book-with-authors")]
    public IActionResult AddBookWithAuthors([FromBody] BookVM book)
    {
      if (ModelState.IsValid)
      {
         _booksService.AddBookWithAuthors(book);
        return Ok();
      }
      return BadRequest();     
    }

    [HttpGet("get-all-books")]
    public IActionResult GetAllBookd()
    {
      var allBooks = _booksService.GetAllBooks();
      return Ok(allBooks);
    }

    [HttpGet("get-book-by-id/{id}")]
    public IActionResult GetBookById(int id)
    {
      var _book = _booksService.GetGookById(id);
      if(_book != null)
      {
        return Ok(_book);
      }
      else
      {
        return NotFound();
      }
    }

    [HttpPut("update-book-by-id/{id}")]
    public IActionResult UpdateBookById(int id, [FromBody] BookVM bookVM)
    {
      if (ModelState.IsValid)
      {
        var _book = _booksService.UpdateBookById(id, bookVM);
        return Created(nameof(UpdateBookById), _book);
      }
      return BadRequest();      
    }

    [HttpDelete("delete-book-by-id/{id}")]
    public IActionResult DeleteBookById(int id)
    {
      try
      {
        _booksService.DeleteBookById(id);
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }      
    }
  }
}
