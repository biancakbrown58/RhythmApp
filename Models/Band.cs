using System;
using System.Collections.Generic;

namespace RhythmApp.Models
{
  public class Band
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryOfOrigin { get; set; }
    public string NumberOfMembers { get; set; }
    public string Website { get; set; }
    public string Style { get; set; }
    public string IsSigned { get; set; }
    public string PersonOfContact { get; set; }
    public string ContactPhoneNumber { get; set; }

    public List<Album> Albums { get; set; }

    // navigation properties est releationship to cohort
    // public int CohortId { get; set; }
    // type of property that points to cohort
    // public Cohort Cohort { get; set; }
  }
}