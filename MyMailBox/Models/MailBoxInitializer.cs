using Microsoft.Extensions.DependencyInjection;

namespace MyMailBox.Models
{
    public static class MailBoxInitializer
    {
        public static void FillDb(this IServiceCollection services)
        {
            using (var serviceScope = services.BuildServiceProvider()
                                              .GetRequiredService<IServiceScopeFactory>()
                                              .CreateScope())
            {
                MailBoxContext context =
                               serviceScope.ServiceProvider.GetService<MailBoxContext>();

                if (context == null)
                    return;
                // On peut détruire puis recréer la base par le code.
                // Pas bon en production
                // utile dans l’exercice pour repartir « propre »
                //context.Database.EnsureDeleted();
                //context.Database.Migrate();
                context.MailBoxes.Add(new MailBox
                {
                    Color = "Anthracite",
                    Name = "Ideal MailBox",
                    Reference = "X624",
                    Depth = 400,
                    Width = 350,
                    Height = 250,
                    ImagePath = "/Images/MailBoxes/MailBox1.jpg"
                });
                // Créer 2 ou 3 boîtes aux lettres supplémentaires ...
                context.SaveChanges();
            }
        }
    }
}
