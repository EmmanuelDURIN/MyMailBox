using System.ComponentModel.DataAnnotations;

namespace MyMailBox.Models
{
  public class Color
  {
    public int Id { get; set; }
    [Required]
    [StringLength(30)] 
    public string Name { get; set; }
  }
}
