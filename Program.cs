using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infeco.Data;
using Infeco.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InfecoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("InfecoContext") ?? throw new InvalidOperationException("Connection string 'InfecoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
