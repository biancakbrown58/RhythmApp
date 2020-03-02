using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RhythmApp.Models
{
  public partial class DatabaseContext : DbContext
  {

    // Add Database tables here
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Band> Bands { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        //#error Make sure to update the connection string to the correct database
        optionsBuilder.UseNpgsql("server=localhost;database=RhythmAppDatabase");
      }
    }
  }
}
