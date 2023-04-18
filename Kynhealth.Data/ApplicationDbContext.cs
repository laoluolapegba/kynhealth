using Kynhealth.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kynhealth.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        private readonly string _connectionString;
        private readonly  IConfiguration _config;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //reducing database "chatter" in code first
            //step 1: turn off initialization -https://romiller.com/2014/06/10/reducing-code-first-database-chatter/
            //Database.SetInitializer<BodcContext>(null);
        }

        public ApplicationDbContext()
        {
           
        }
        private void OnEntityUpdating()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedAt = now;
                            break;
                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.UpdatedAt = now;
                            break;
                    }
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseOracle(@"Data Source=10.161.10.195:1525/epin;User ID=epin;Password=emts818!", options => options
                //.UseOracleSQLCompatibility("11"));
                    

            }
            
        }
        public override int SaveChanges()
        {
            OnEntityUpdating();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnEntityUpdating();
            return base.SaveChangesAsync(cancellationToken);
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

            //builder.Entity<Organization>().HasMany(cg => cg.Users).WithOne(bb => bb.Organization).HasForeignKey(a=>a.Id);
            //builder.Entity<Lga>().HasMany(cg => cg.Oranizations).WithOne(bb => bb.lgas).HasForeignKey(a=>a.LocalGovtId);
            //builder.Entity<Country>().HasMany(cg => cg.Oranizations).WithOne(bb => bb.countries).HasForeignKey(a=>a.CountryId);
            //builder.Entity<State>().HasMany(cg => cg.Oranizations).WithOne(bb => bb.states).HasForeignKey(a=>a.StateId);

            builder.Entity<Organization>()
                .HasMany(cg => cg.UsersCollection)
                .WithOne(bb => bb.Organization);            

            builder.Entity<ApplicationUser>()
                .HasOne(a=>a.Organization)
                .WithMany(bc => bc.UsersCollection)
                .HasForeignKey(a=>a.OrganizationCompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Lga>()
                .HasMany(cg => cg.OranizationCollection)
                .WithOne(bb => bb.Lga);

            builder.Entity<Organization>()
                .HasOne(a=>a.Lga)
                .WithMany(b => b.OranizationCollection)
                .HasForeignKey(a=>a.LocalGovtId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<State>()
                .HasMany(cg => cg.OranizationCollection)
                .WithOne(b => b.State);
            builder.Entity<Organization>()
               .HasOne(a => a.State)
               .WithMany(b => b.OranizationCollection)
               .HasForeignKey(a => a.StateId)
               .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<Country>()
                .HasMany(cg => cg.OranizationCollection)
                .WithOne(bb => bb.Country);

            builder.Entity<Organization>()
               .HasOne(a => a.Country)
               .WithMany(b => b.OranizationCollection)
               .HasForeignKey(a => a.CountryId)
               .OnDelete(DeleteBehavior.NoAction);



            


        }

        public void SeedData()
        {
            SeedRoles();
        }
        private void SeedRoles()
        {
            //var roles = new List<string>() { "User", "Admin" };

            //roles.ForEach((role) =>
            //{
            //    var exists = Roles.Any(x => x.Name == role);

            //    if (!exists)
            //    {
            //        Roles.Add(new Role
            //        {
            //            Id = Guid.NewGuid().ToString(),
            //            Name = role,
            //            NormalizedName = role.ToUpper(),
            //            ConcurrencyStamp = Guid.NewGuid().ToString()
            //        });
            //    }
            //});
        }
        public static class ModelBuilderExtensions
        {
            //public static void SetupEnumStringConverters(this ModelBuilder builder)
            //{
            //    foreach (var entityType in builder.Model.GetEntityTypes())
            //    {
            //        foreach (var property in entityType.GetProperties())
            //        {
            //            if (property.ClrType.IsEnum)
            //            {
            //                builder.Entity(entityType.Name)
            //                    .Property(property.Name)
            //                    .HasConversion<string>();
            //            }
            //        }
            //    }
            //}
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Lga> Lgas { get; set; }
        public DbSet<Organization> Org { get; set; }
    }
}

