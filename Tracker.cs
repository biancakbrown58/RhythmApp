using System;
using System.Linq;
using RhythmApp.Models;

namespace RhythmApp
{
  public class Tracker
  {
    //var db = new DatabaseContext();
    //public List<Band> Bands { get; set; } = new List<Band>();
    public void PopulateDatabase()
    {
      var db = new DatabaseContext();
      if (!db.Bands.Any())
      {
        db.Bands.Add(new Band
        {
          Name = "The Chats",
          CountryOfOrigin = "Australia",
          NumberOfMembers = "3",
          Website = "thechatslovebeer.com",
          Style = "Punk",
          IsSigned = "yes",
          PersonOfContact = "Eamon",
          ContactPhoneNumber = "727-530-3520"
        });
        db.Bands.Add(new Band
        {
          Name = "Orville Peck",
          CountryOfOrigin = "Canada",
          NumberOfMembers = "4",
          Website = "orvillepeck.com",
          Style = "Country",
          IsSigned = "yes",
          PersonOfContact = "Orville",
          ContactPhoneNumber = "727-539-2232"
        });
        db.SaveChanges();
      }
    }
    public void AddABand(string name, string countryOfOrigin, string numberOfMembers, string website, string style, string isSigned, string personOfContact, string contactPhoneNumber)
    {
      var db = new DatabaseContext();
      var newBand = new Band
      {
        Name = name,
        CountryOfOrigin = countryOfOrigin,
        NumberOfMembers = numberOfMembers,
        Website = website,
        Style = style,
        IsSigned = isSigned,
        PersonOfContact = personOfContact,
        ContactPhoneNumber = contactPhoneNumber
      };
      db.Bands.Add(newBand);
      db.SaveChanges();
    }

    public void AddAnAlbum(string albumTitle, int bandId, string isExplicit)
    {
      var db = new DatabaseContext();
      var album = new Album
      {
        Title = albumTitle,
        BandId = bandId,
        ReleaseDate = DateTime.Now,
        IsExplicit = isExplicit
      };
      db.Albums.Add(album);
      db.SaveChanges();
    }

    public void AddSongs(string songTitle, string lyrics, string length, string genre, int albumId)
    {
      var db = new DatabaseContext();
      var song = new Song
      {
        Title = songTitle,
        Lyrics = lyrics,
        Length = length,
        Genre = genre,
        AlbumId = albumId
      };
      db.Songs.Add(song);
      db.SaveChanges();
    }


    public void ViewSignedBands(string isSigned, string type)
    {
      var db = new DatabaseContext();
      Console.WriteLine($"These are the bands that are {type}");

      var bands = db.Bands.Where(a => a.IsSigned == isSigned);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Name} - {band.IsSigned}");
      }
    }
    public void UpdateIsSigned(string isSigned, string type)
    {
      var db = new DatabaseContext();
      Console.WriteLine("What band would you like to sign or unsign?");
      var bands = db.Bands.OrderBy(b => b.Name);
      foreach (var band in bands)
      {
        Console.WriteLine($"{band.Id}: {band.Name}");
      }
      var bandId = int.Parse(Console.ReadLine());
      Console.WriteLine($" " + bandId);

      var updateSigned = db.Bands.First(c => c.Id == bandId);
      if (isSigned == "yes")
      {
        updateSigned.IsSigned = "no";
      }
      else
      {
        updateSigned.IsSigned = "yes";
      }
      db.SaveChanges();
      Console.WriteLine($"bands contract has been {type}");

    }

    //public void ViewBandAlbums(string title)
    // {

    // var db = new DatabaseContext();
    // Console.WriteLine("what band would you like to view albums from?");
    //     var albums = db.Albums.OrderBy(a => a.Title);
    //     foreach (var album in albums)
    //     {
    //       Console.WriteLine($"{album.Id}: {album.Title}");
    //     }
    //     var albumId = int.Parse(Console.ReadLine());
    //////////////////////
    // Console.WriteLine("what band would you like to view albums from?");
    // var bands = db.Bands.OrderBy(b => b.Name);
    // foreach (var band in bands)
    // {
    //   Console.WriteLine($"{band.Id}: {band.Name}");
    // }
    // var bandId = int.Parse(Console.ReadLine());
    // var albums = db.Albums.OrderBy(a => a.Title);
    // foreach (var album in albums)
    // {
    //   Console.WriteLine($"{album.Title}");
    // }
    // }
  }
}
