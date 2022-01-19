using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApp_Book.Data;
using Test_WebApp_Book.Data.Models;

namespace Test_WebApp_Book.Services
{
  public class LogsService
  {
    private readonly AppDbContext _context;
    public LogsService(AppDbContext context)
    {
      _context = context;
    }

    public List<Log> GetAllLogsFromDB() => _context.Logs.ToList();
    
  }
}
