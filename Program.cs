using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using evaluation.Data; // Make sure to replace 'YourNamespace' with the actual namespace
using evaluation.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Read configuration from environment variables and .env file
var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile(".env", optional: true, reloadOnChange: true)
    .Build();

// Get database connection information from configuration
string dbHost = configuration["DB_HOST"];
string dbName = configuration["DB_NAME"];
string dbUser = configuration["DB_USER"];
string dbPassword = configuration["DB_PASSWORD"];

// Construct the connection string using the values from configuration
string connectionString = $"Server=db4free.net;Database=appdbs;User=jmacalawa;Password=wew123WEW;";

try
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
catch (Exception ex)
{
    Console.WriteLine($"Error while setting up the database context: {ex.Message}");
    throw; // Rethrow the exception to halt application setup
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
