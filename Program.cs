using DemoMVC2.Data;

using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ConnectionString

/*    
builder.Services.AddDbContext<DataContext>(
    options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
*/

builder.Services.AddDbContext<DataContext>(
    options => 
    options.UseSqlServer(@"Data Source=DESKTOP-SO605I4\SQLEXPRESS;Database=DbProducto; Integrated Security=True;;TrustServerCertificate=Yes"));

   



var app = builder.Build();

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
