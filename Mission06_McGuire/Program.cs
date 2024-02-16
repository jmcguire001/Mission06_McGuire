/* IS 413 - Mission 6
 * Jacob McGuire
 * Section 002, Group 3
 * 
 * This app is to create a webapp for a movie database
*/

// Declare what namespaces and models are being used
using Mission06_McGuire.Models;
using Microsoft.EntityFrameworkCore;

// Create a class
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
}); // This service is for Sqlite

// Create the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Add the middleware to the pipeline
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the app
app.Run();
