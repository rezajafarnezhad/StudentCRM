
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Service.Contracts;
using StudentCRM.Service.Impl;
using StudentCRM.web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var ConnectionString = builder.Configuration.GetConnectionString("DBBS");
//اضافه کردن دیتابیس
builder.Services.AddDbContextService(ConnectionString);
//AutoMapper


//اضافه کردن Identity
builder.Services.AddIdentityService();

builder.Services.AddScoped<IUnitOfWork>(serviceProvider =>
    serviceProvider.GetRequiredService<ApplicationDbContext>());
builder.Services.AddScoped<ItermService, termService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IStudentResultService,StudentResultService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
