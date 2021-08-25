using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace MyMailBox.Models
{
    public class MailBoxContext : DbContext
    {
        public MailBoxContext(DbContextOptions<MailBoxContext> options)
                : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<MailBox> MailBoxes { get; set; }
    }
}
