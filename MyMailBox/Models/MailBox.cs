using System.ComponentModel.DataAnnotations;

namespace MyMailBox.Models
{
  public class MailBox
  {
    public int Id { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
    public Color Color { get; set; }
    public int ColorId { get; set; }
    [Display(Name = "Image")]
    public string ImagePath { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Depth { get; set; }
  }
}
