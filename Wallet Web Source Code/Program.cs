using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Numerics;
using System;




        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //DI
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();


//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VVhhQlFac1pJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkNjWn9edHNRRmZYWEM=");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); ;

        app.UseAuthorization();

        app.MapRazorPages();
/*
app.Use(async (context, next) =>
{
    // Get the SignInManager and UserManager from the request services
    var signInManager = context.RequestServices.GetRequiredService<SignInManager<IdentityUser>>();
    var userManager = context.RequestServices.GetRequiredService<UserManager<IdentityUser>>();

    // Check if the user is signed in
    var isSignedIn = signInManager.IsSignedIn(context.User);

    // Check if the request path is the root path
    var isRootPath = context.Request.Path == "/";

    // If the user is signed in and the request path is the root path, redirect to the dashboard page
    if (isSignedIn && isRootPath)
    {
        context.Response.Redirect("/Dashboard/Index");
    }
    // If the user is not signed in and the request path is the root path, redirect to the landing page
    else if (!isSignedIn && isRootPath)
    {
        context.Response.Redirect("/Home/Landing");
    }
    // Otherwise, continue the request
    else
    {
        await next();
    }
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});*/

app.MapControllerRoute(
  name: "default",
pattern: "{controller=Dashboard}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Landing}/{id?}");



app.Run();
