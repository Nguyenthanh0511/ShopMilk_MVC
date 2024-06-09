using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.Data;
using Model.Entities;
using Service.IService;
using Service.Service;
using WebsiteBanSua_L.Reponsive.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string getConnectionToString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebsiteBanSua_LContext>(options => options.UseSqlServer(getConnectionToString));

// Register repositories
//builder.Services.AddScoped<IProductRepo, ProductRepo>();
//builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IBaseRepo<Category>,BaseRepo<Category>>();
builder.Services.AddScoped<IBaseRepo<Product>, BaseRepo<Product>>();
builder.Services.AddScoped<IBaseRepo<Users>, BaseRepo<Users>>();
builder.Services.AddScoped<IBaseRepo<CartDetail>, BaseRepo<CartDetail>>();
builder.Services.AddScoped<IBaseRepo<Image>, BaseRepo<Image>>();
// Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddHttpContextAccessor(); // Đăng ký IHttpContextAccessor
builder.Services.AddSession(); // Cấu hình dịch vụ Session
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSession();

app.MapAreaControllerRoute(
    name: "Administrator",
    areaName: "Administrator",
    pattern: "Administrator/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var datainit = new DataInitializer(app.Services);
datainit.Seed();

app.Run();
