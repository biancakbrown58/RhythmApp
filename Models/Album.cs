using System;
using System.Collections.Generic;

namespace RhythmApp.Models
{
  public class Album
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string IsExplicit { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int BandId { get; set; }
    public Band Band { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();

    // navigation properties est releationship to cohort

    // type of property that points to cohort
    // public Cohort Cohort { get; set; }
  }
}