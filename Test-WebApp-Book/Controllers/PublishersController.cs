using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
  public class PublishersController : ControllerBase
  {
    private readonly PublisherService _publisherService;
    private readonly ILogger<PublishersController> _logger;
    public PublishersController(PublisherService publisherService, ILogger<PublishersController> logger)
    {
      _publisherService = publisherService;
      _logger = logger;
    }

    [HttpGet("get-all-publicshers")]
    public IActionResult GetAllPublishers(string sss)
    {
      _logger.LogInformation($"sss {sss}");
      var allPublishers = _publisherService.GetAllPublishers();
      return Ok(allPublishers);
    }

    [HttpGet("get-publisher-by-id/{id}")]
    public IActionResult GetPublisherById(int id)
    {
      var _publisher = _publisherService.GetPublisherById(id);
      if(_publisher != null)
      {
        return Ok(_publisher);
      }
      else
      {
        return NotFound();
      }      
    }

    [HttpGet("get-publisher-books-with-authors/{id}")]
    public IActionResult GetPublisherData(int id)
    {
      var _publisherData = _publisherService.GetPublisherData(id);
      if(_publisherData != null)
      {
        return Ok(_publisherData);
      }
      else
      {
        return NotFound();
      }
    }

    [HttpPost("add-publisher")]
    public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
    {
      var _publisher = _publisherService.AddPublisher(publisherVM);
      return Created(nameof(AddPublisher), _publisher);
    }

    [HttpPut("edit-publisher-by-id")]
    public IActionResult EditPublisherById(int id, [FromBody] PublisherVM publisherVM) 
    {
      var updatePublisher = _publisherService.EditPublisherById(id, publisherVM);
      return Created(nameof(EditPublisherById), updatePublisher);     
    }

    [HttpDelete("delete-publisher-by-id/{id}")]
    public IActionResult DeletePublisherById(int id)
    {
      try
      {
        _publisherService.DeletePublisherById(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }     
    }    
  }
}
