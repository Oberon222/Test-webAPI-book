using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApp_Book.Data.Models;

namespace Test_WebApp_Book.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Book_Author>()
        .HasOne(n => n.Book)
        .WithMany(n => n.Book_Authors)
        .HasForeignKey(bi => bi.BookId);

      modelBuilder.Entity<Book_Author>()
        .HasOne(b => b.Author)
        .WithMany(ba => ba.Book_Authors)
        .HasForeignKey(bi => bi.AuthorId);

      modelBuilder.Entity<Log>().HasKey(n => n.Id);

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book_Author> Book_Authors { get; set; }
    public DbSet<Log> Logs { get; set; }
  }
}
