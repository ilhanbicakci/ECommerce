using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Principal;
using UI.WebPage;
using UI.WebPage.Models;


namespace UI.WebPage.Models
{
    public static class IdentityExtensions
    {
        public static ApplicationUser GetUser(this IIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                using(var db= new ApplicationDbContext())
                {
                    var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                    return userManager.FindByName(identity.Name);
                }
            }
            return null;
        }
    }
}
