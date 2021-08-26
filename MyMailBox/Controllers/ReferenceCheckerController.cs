using Microsoft.AspNetCore.Mvc;
using MyMailBox.Business;
using MyMailBox.Models;
using System.Linq;

namespace MyMailBox.Controllers
{
  public class ReferenceCheckerController : Controller
  {
    private readonly MailBoxService mailBoxService;

    public ReferenceCheckerController(MailBoxService mailBoxService)
    {
      this.mailBoxService = mailBoxService;
    }
    public JsonResult CheckReferenceUnicity(string reference)
    {
      if (!mailBoxService.DoesReferenceExists(reference))
        return Json(true);
      else
        return Json("Reference already exists");
    }
    public JsonResult CheckReferenceExistence(string reference)
    {
      if (mailBoxService.DoesReferenceExists(reference))
        return Json(true);
      else
        return Json("Reference doesn't exist");
    }
  }
}
