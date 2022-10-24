using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Review 
  {
    public int ReviewId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
  }
}