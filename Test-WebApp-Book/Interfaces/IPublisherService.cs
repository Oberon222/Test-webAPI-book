using System.Collections.Generic;
using Test_WebApp_Book.Data.Models;
using Test_WebApp_Book.Data.ViewModels;

namespace Test_WebApp_Book.Interfaces
{
  public interface IPublisherService
  {
    List<Publisher> GetAllPublishers();
    Publisher AddPublisher(PublisherVM publisherVM);
    Publisher GetPublisherById(int id);
    Publisher EditPublisherById(int id, PublisherVM publisherVM);
    void DeletePublisherById(int id);
  }
}
