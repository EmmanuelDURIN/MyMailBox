using Microsoft.AspNetCore.Mvc;
using MyMailBox.Models;
using System;
using System.Linq;

namespace MyMailBox.Controllers
{
  public class MailBoxController : Controller
  {
    private readonly MailBoxContext context;

    public MailBoxController(MailBoxContext context)
    {
      this.context = context;
    }
    public IActionResult Index(String reference)
    {
      if (reference == null)
        return BadRequest("reference required");
      MailBox mailBox = null;
      mailBox = context.MailBoxes.FirstOrDefault(
             mb => mb.Reference.ToUpper() == reference.ToUpper());
      if (mailBox == null)
        return NotFound($"mailbox with refrence {reference} not found");
      return View(mailBox);
    }
  }
}
