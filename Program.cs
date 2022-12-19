using ENSC.Data;
using System.Text.Json.Serialization;
using ENSC.Models;

var builder = WebApplication.CreateBuilder(args);

//To ignore cicular references
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ENSCContext>();

var app = builder.Build();

//Put datas in DB if it's empty
SeedData.InitBd();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();