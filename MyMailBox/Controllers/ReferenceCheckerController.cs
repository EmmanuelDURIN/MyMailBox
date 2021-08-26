using Microsoft.AspNetCore.Mvc;
using MyMailBox.Models;
using System.Linq;

namespace MyMailBox.Controllers
{
  public class ReferenceCheckerController : Controller
  {
    private readonly MailBoxContext _context;

    public ReferenceCheckerController(MailBoxContext context)
    {
      _context = context;
    }
    public JsonResult CheckReferenceUnicity(string reference)
    {
      if (!DoesReferenceExists(reference))
        return Json(true);
      else
        return Json("Reference already exists");
    }
    public JsonResult CheckReferenceExistence(string reference)
    {
      if (DoesReferenceExists(reference))
        return Json(true);
      else
        return Json("Reference doesn't exist");
    }
    private bool DoesReferenceExists(string reference)
    {
      return _context.MailBoxes.Any(mb => mb.Reference == reference);
    }
  }
}
