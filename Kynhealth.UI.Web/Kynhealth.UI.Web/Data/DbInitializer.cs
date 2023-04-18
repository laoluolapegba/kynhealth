using Kynhealth.Data;

namespace Kynhealth.UI.Web.Data
{
    internal class DbInitializer
    {
        internal static void Initialize(ApplicationDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Users.Any()) return;

            //var users = new User[]
            //{
            //new User{ Id = 1, Name = "Bruce Wayne" }
            ////add other users
            //};

            //foreach (var user in users)
            //    dbContext.Users.Add(user);


            dbContext.SaveChanges();
        }
    }
}
