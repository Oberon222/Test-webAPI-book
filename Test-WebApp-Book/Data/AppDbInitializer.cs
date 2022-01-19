using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_WebApp_Book.Data
{
  public class AppDbInitializer
  {
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
      using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        if (!context.Books.Any())
        {
          context.Books.AddRange(new Models.Book()
          {
            Title = "C# для профессионалов: тонкости программирования",
            Description= "C# для профессионалов: тонкости программирования, " +
            "3-е издание, новый перевод (C# in Depth) является обновлением предыдущего издания, " +
            "ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, " +
            "которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные " +
            "сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит.",
            IsRead = true,
            DateAdded = DateTime.Now.AddDays(-12),
            Genre="Programming",
            ImageURL= "https://content1.rozetka.com.ua/goods/images/big/10828697.jpg"

          });
          context.SaveChanges();
        }
      }
    }
  }
}
