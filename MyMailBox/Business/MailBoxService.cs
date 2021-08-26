using MyMailBox.Models;
using System.Linq;

namespace MyMailBox.Business
{
  public class MailBoxService
  {
    private readonly MailBoxContext context;
    public MailBoxService(MailBoxContext context)
    {
      this.context = context;
    }
    public bool DoesReferenceExists(string reference)
    {
      return context.MailBoxes.Any(mb => mb.Reference == reference);
    }
  }
}
