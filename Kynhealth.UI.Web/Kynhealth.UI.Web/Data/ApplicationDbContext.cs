using Kynhealth.Entities;
using Kynhealth.UI.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kynhealth.UI.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "kyn_users");
            });
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "kyn_users");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "kyn_roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("kyn_user_roles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("kyn_user_claims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("kyn_logins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("kyn_roleclaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("kyn_usertokens");
            });

            builder.Entity<Organization>().HasMany(cg => cg.Users).WithOne(bb => bb.Organization);
            builder.Entity<Lga>().HasMany(cg => cg.Oranizations).WithOne(bb => bb.lgas);
            builder.Entity<Country>().HasMany(cg => cg.Oranizations).WithOne(bb => bb.countries);
            builder.Entity<State>().HasMany(cg => cg.Oranizations).WithOne(bb => bb.states);
        }

        
    }
}