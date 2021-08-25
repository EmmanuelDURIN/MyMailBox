using Microsoft.AspNetCore.Mvc;
using MyMailBox.Models;
using System;

namespace MyMailBox.Controllers
{
  public class MailBoxController : Controller
  {
    public IActionResult Index(String reference)
    {
      var mailbox = new MailBox()
      {
        Reference = "X503",
        Id = 1,
        Color = "Red",
        Depth = 200,
        Width = 200,
        Height = 200,
        ImagePath = "images/mailboxes/mailbox1.jpg",
        Name = "Ideal mailbox",
      };
      return View(model: mailbox);
    }
  }
}
