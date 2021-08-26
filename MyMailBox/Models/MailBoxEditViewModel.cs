using Microsoft.AspNetCore.Mvc;
using MyMailBox.Controllers;
using MyMailBox.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyMailBox.Models
{
  public class MailBoxEditViewModel
  {
    public int Id { get; set; }
    [Required]
    [StringLength(10)]
    [ReferenceValidation(Letter = 'X')]
    [Remote(action: nameof(ReferenceCheckerController.CheckReferenceExistence), controller: "ReferenceChecker")]
    public string Reference { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    public Color Color { get; set; }
    public int ColorId { get; set; }
    [StringLength(255)]
    [Display(Name = "Image")]
    public string ImagePath { get; set; }
    [Range(0, 10_000)]
    public double Height { get; set; }
    [Range(0, 10_000)]
    public double Width { get; set; }
    [Range(0, 10_000)]
    public double Depth { get; set; }
  }
}
