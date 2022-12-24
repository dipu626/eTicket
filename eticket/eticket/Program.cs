using eticket.Data;
using eticket.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext configuration
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnectionString"];

Console.WriteLine(connectionString);

// DBContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Service Configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<ICinemasService, CinemaService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();

// Add services to the container.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed Database
//AppDbInitializer.Delete(app);
//AppDbInitializer.Seed(app);

app.Run();
