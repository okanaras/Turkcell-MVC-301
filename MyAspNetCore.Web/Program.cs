using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyAspNetCore.Web.Helpers;
using MyAspNetCore.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// app builderin hemen yukarisina 
// builder.Services.AddDbContext<AppDbContext>(options => {options.useSqlServer(builder.Configuration.GetConnectionString("SqlCon"))} parantez actik parametre olarak options girdik daha sonra lambda ile suslu acip option.usesqlServer parantez builder.configuration.getConnString parantez "SqlConn" dedik
builder.Services.AddDbContext<AppDbContext>(options =>

{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
}

);

// builder.Services.AddSingleton<IHelper, Helper>(); //singleton ornek icin
// builder.Services.AddScoped<IHelper, Helper>(); // scoped icinde gerekkli
builder.Services.AddTransient<IHelper, Helper>();



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
