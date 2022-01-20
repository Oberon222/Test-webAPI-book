using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApp_Book.Data.ViewModels;
using Test_WebApp_Book.Services;

namespace Test_WebApp_Book.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthorsController : ControllerBase
  {
    private readonly AuthorService _authorService;
    public AuthorsController(AuthorService authorService)
    {
      _authorService = authorService;
    }

    [HttpPost("add-author")]
    public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
    {
      if (ModelState.IsValid)
      {
        var _author = _authorService.AddAuthor(authorVM);
        return Created(nameof(AddAuthor), _author);
      }
      return BadRequest();     
    }

    [HttpGet("get-author-with-books/{id}")]
    public IActionResult GetAuthorWithBooks(int id)
    {
      var _author = _authorService.GetAuthorWithBooks(id);
      if(_author != null)
      {
        return Ok(_author);
      }
      else
      {
        return NotFound();
      }
    }

    [HttpGet("get-all-authors")]
    public IActionResult GetAllAuthors()
    {
      var _allAuthors = _authorService.GetAllAuthors();
      return Ok(_allAuthors);
    }

    [HttpGet("get-author-by-id/{id}")]
    public IActionResult GetAuthorById(int id)
    {
      var _author = _authorService.GetAuhtorById(id);
      return Ok(_author);
    }

    [HttpPut("update-author-by-id/{id}")]
    public IActionResult UpdateAuthorById(int id, [FromBody] AuthorVM authorVM)
    {
      var _updateAuthor = _authorService.UpdateAuthorById(id, authorVM);
      return Created(nameof(UpdateAuthorById), _updateAuthor);
    }

    [HttpDelete("delete-author/{id}")]
    public IActionResult DeleteAuthor(int id)
    {
      try
      {
        _authorService.DeleteAuthor(id);
        return NoContent();
      }
      catch (Exception ex)
      {       
        return BadRequest(ex.Message);
      }
    }
  }
}
