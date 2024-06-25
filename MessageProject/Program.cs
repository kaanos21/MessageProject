using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFrameWork;
using EntityLayer.Concrete;
using MessageProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<User,UserRole>().AddEntityFrameworkStores<Context>();
// Add services to the container.
builder.Services.AddScoped<IMessageService,MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();



builder.Services.AddControllersWithViews();




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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

