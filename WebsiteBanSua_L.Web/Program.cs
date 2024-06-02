using Microsoft.EntityFrameworkCore;
using Model.Data;
using Service.IService;
using Service.Service;
using WebsiteBanSua_L.Reponsive.IReponsive;
using WebsiteBanSua_L.Reponsive.Reponsive;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string getConnectionToString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebsiteBanSua_LContext>(options => options.UseSqlServer(getConnectionToString));

//Repo
builder.Services.AddScoped<IProductRepo, ProductRepo>();

//Service
builder.Services.AddScoped<IProductService,ProductService>();
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
