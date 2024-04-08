using Castle.Components.DictionaryAdapter.Xml;
using ECommerce.BLL.Managers.Abstracts;
using ECommerce.BLL.Managers.Concretes;
using ECommerce.DAL.ContextClasses;
using Microsoft.EntityFrameworkCore;
using ECommerce.BLL.ServiceInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
