using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//access to real database
builder.Services.AddDbContextPool<OdeToFoodDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OdeToFoodDb")));


//Ron's adding code, in memory database
//builder.Services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

builder.Services.AddScoped<IRestaurantData,SqlRestaurantData>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
