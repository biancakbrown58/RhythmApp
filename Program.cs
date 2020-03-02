using System;
using System.Collections.Generic;
using RhythmApp.Models;
using System.Linq;

namespace RhythmApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the Rhythm App!");
      var tracker = new Tracker();
      tracker.PopulateDatabase();
      Console.WriteLine("What would you like to do?");
      var db = new DatabaseContext();
      var isRunning = true;
      while (isRunning)
      {
        Console.WriteLine($"Add: (addband) (addalbum) (addsong)");
        Console.WriteLine($"View Album Info: (viewalbum) (viewsong) (viewrelease)");
        Console.WriteLine($"View Band Contract Info: (signed) (notsigned)");
        Console.WriteLine($"Update Band Contract: (renew) (cancel)");
        Console.WriteLine($"(quit)");

        var input = Console.ReadLine();
        if (input == "addband")
        {
          Console.WriteLine("What is the band name?");
          var name = Console.ReadLine();
          Console.WriteLine("Whats their country of origin?");
          var countryOfOrigin = Console.ReadLine();
          Console.WriteLine("How many members are in this band?");
          var numberOfMembers = Console.ReadLine();
          Console.WriteLine("What is their website?");
          var website = Console.ReadLine();
          Console.WriteLine("What genre of music is it?");
          var style = Console.ReadLine();
          Console.WriteLine("Are they signed? type: yes or no");
          var isSigned = Console.ReadLine();
          Console.WriteLine("Who is the contact for this band?");
          var personOfContact = Console.ReadLine();
          Console.WriteLine($"What is {personOfContact}'s phone number?");
          var contactPhoneNumber = Console.ReadLine();
          tracker.AddABand(name, countryOfOrigin, numberOfMembers, website, style, isSigned, personOfContact, contactPhoneNumber);
          db.SaveChanges();
        }
        //add album to band
        else if (input == "addalbum")
        {
          Console.WriteLine("What band would you like to add an album to?");
          // view bands =
          var bands = db.Bands.OrderBy(b => b.Name);
          foreach (var band in bands)
          {
            Console.WriteLine($"{band.Id}: {band.Name}");
          }
          // select band by id
          var bandId = int.Parse(Console.ReadLine());
          Console.WriteLine($"You are adding and album to " + bandId);
          var bandToAdd = db.Bands.First(c => c.Id == bandId);
          // ask user info about album
          Console.WriteLine("What is the album name?");
          var albumTitle = Console.ReadLine();
          Console.WriteLine("Is it explicit?");
          var isExplicit = Console.ReadLine();
          // add and save changes
          tracker.AddAnAlbum(albumTitle, bandId, isExplicit);
          db.SaveChanges();
        }
        //add a song to an album
        else if (input == "addsong")
        {
          Console.WriteLine("What album would you like to add songs to?");
          var albums = db.Albums.OrderBy(a => a.Title);
          foreach (var album in albums)
          {
            Console.WriteLine($"{album.Id}: {album.Title}");
          }
          var albumId = int.Parse(Console.ReadLine());
          Console.WriteLine("What is the song title?");
          var songTitle = Console.ReadLine();
          Console.WriteLine("What are some of the lyrics?");
          var lyrics = Console.ReadLine();
          Console.WriteLine("How long is the song?");
          var length = Console.ReadLine();
          Console.WriteLine("What genre of music is this song?");
          var genre = Console.ReadLine();
          tracker.AddSongs(songTitle, lyrics, length, genre, albumId);
          db.SaveChanges();
        }
        // view band albums
        else if (input == "viewalbum")
        {
          Console.WriteLine("What band would you like to view albums from?");
          var bands = db.Bands.OrderBy(b => b.Name);
          foreach (var band in bands)
          {
            Console.WriteLine($"{band.Id}: {band.Name}");
          }
          var bandId = int.Parse(Console.ReadLine());
          var albums = db.Albums.Where(a => bandId == a.BandId);
          foreach (var album in albums)
          {
            Console.WriteLine($"{album.Title}");
          }
        }
        else if (input == "viewsong")
        {
          Console.WriteLine($"What album would you like to view songs from?");
          var albums = db.Albums.OrderBy(a => a.Title);
          foreach (var album in albums)
          {
            Console.WriteLine($"{album.Id}: {album.Title}");
          }
          var albumId = int.Parse(Console.ReadLine());
          var songs = db.Songs.Where(s => albumId == s.AlbumId);
          foreach (var song in songs)
          {
            Console.WriteLine($"{song.Title}");
          }
        }
        else if (input == "viewrelease")
        {
          Console.WriteLine($"These are the albums in order by release date.");
          var albums = db.Albums.OrderBy(a => a.ReleaseDate);
          foreach (var album in albums)
          {
            Console.WriteLine($"{album.Title} - {album.ReleaseDate}");
          }
        }
        else if (input == "signed")
        {
          tracker.ViewSignedBands("true", "signed");
        }
        else if (input == "notsigned")
        {
          tracker.ViewSignedBands("false", "notsigned");
        }
        else if (input == "renew")
        {
          tracker.UpdateIsSigned("no", "signed");
        }
        else if (input == "cancel")
        {
          tracker.UpdateIsSigned("yes", "un-signed");
        }

        else if (input == "quit")
        {
          isRunning = false;
        }
      }
    }
  }
}
