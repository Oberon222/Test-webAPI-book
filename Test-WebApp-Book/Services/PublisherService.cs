using System;
using System.Collections.Generic;
using System.Linq;
using Test_WebApp_Book.Data;
using Test_WebApp_Book.Data.Models;
using Test_WebApp_Book.Data.ViewModels;
using Test_WebApp_Book.Interfaces;

namespace Test_WebApp_Book.Services
{
  public class PublisherService : IPublisherService
  {
    private readonly AppDbContext _context;
    public PublisherService(AppDbContext context)
    {
      _context = context;
    }

    public List<Publisher> GetAllPublishers()
    {
      var allPublishers = _context.Publishers.ToList();
      return allPublishers;
    }

    public Publisher AddPublisher(PublisherVM publisherVM)
    {
      var _publisher = new Publisher()
      {
        Name = publisherVM.Name
      };

      _context.Publishers.Add(_publisher);
      _context.SaveChanges();

      return _publisher;
    }

    public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(p => p.Id == id);

    public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
    {
      var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
        .Select(n => new PublisherWithBooksAndAuthorsVM()
        {
          Name = n.Name,
          BookAuthors = n.Books.Select(n => new BookAuthorVM()
          {
            BookName = n.Title,
            BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
          }).ToList()
        }).FirstOrDefault();
      return _publisherData;
    }

    public Publisher EditPublisherById(int id, PublisherVM publisherVM)
    {
      var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
      if (_publisher != null)
      {
        _publisher.Name = publisherVM.Name;
      }
      _context.SaveChanges();
      return _publisher;
    }

    public void DeletePublisherById(int id)
    {
      var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
      if(_publisher != null)
      {
        _context.Publishers.Remove(_publisher);
        _context.SaveChanges();
      }
      else
      {
        throw new Exception($"The publisher with id: {id} does not found");
      }
    }
  }
}
