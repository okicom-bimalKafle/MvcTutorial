using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mvc.Data;
using Mvc.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcContext") ?? throw new InvalidOperationException("Connection string 'MvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DataSeeder.Initialize(services);
}
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
