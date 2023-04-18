using Kynhealth.Data;
using Kynhealth.Entities;
using Kynhealth.Services.Organizations;
using Kynhealth.UI.Web.Data;
using Kynhealth.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Kynhealth.UI.Web.Models.Mapper;
using Kynhealth.Services.Locations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("IdentityDb");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySql(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, 
    new MySqlServerVersion(new Version(5, 7)
    ),
    o=>o.SchemaBehavior(Pomelo.EntityFrameworkCore.MySql.Infrastructure.MySqlSchemaBehavior.Ignore)
    ));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
.AddDefaultTokenProviders();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<ILocationService, LocationService>();

//builder.Services.AddScoped<UserManager<ApplicationUser>>();
//builder.Services.AddScoped<RoleManager<IdentityRole>>();

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(cke => { cke.LoginPath = "/Identity/Account/Login"; });
//builder.Services.AddMvc(o =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    o.Filters.Add(new AuthorizeFilter(policy));
//});
//builder.Services.AddMvc()
//        .AddRazorPagesOptions(options =>
//        {
//            //options.AllowAreas = true;
//            options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
//            options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
//        }); 

var app = builder.Build();
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        if (!context.Roles.Any())
        {
            await ContextSeed.SeedRolesAsync(userManager, roleManager);
        }
        
        if (!context.Users.Any())
        {
            await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
        }
        
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred seeding the roles to the database.");
    }
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();

app.Run();
