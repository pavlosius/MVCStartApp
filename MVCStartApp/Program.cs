using CoreStartApp.Middlewares;
using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;
using MVCStartApp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection));

builder.Services.AddDbContext<LoggingContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

// ����������� ������� ����������� ��� �������������� � ����� ������
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

// ����������� ������� ����������� ��� ����������� �������� � ���� ������
builder.Services.AddSingleton<IRequestRepository, RequestRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// ���������� ����������� � �������������� �� �������������� ����
app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
