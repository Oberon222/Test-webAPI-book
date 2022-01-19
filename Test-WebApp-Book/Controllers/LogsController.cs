using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApp_Book.Services;

namespace Test_WebApp_Book.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LogsController : ControllerBase
  {
    private readonly LogsService _logsService;
    public LogsController(LogsService logsService)
    {
      _logsService = logsService;
    }

    [HttpGet("get-all-logs")]
    public IActionResult GetAllLogs()
    {
      try
      {
        var allLogs = _logsService.GetAllLogsFromDB();
        return Ok(allLogs);
      }
      catch (Exception)
      {
        return BadRequest("Could not load logs");        
      }
    }
  }
}
