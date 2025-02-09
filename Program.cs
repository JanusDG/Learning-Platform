using Microsoft.EntityFrameworkCore;
using LearningPlatform.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();



// Register DbContext with dependency injection using SQL Server
builder.Services.AddDbContext<LearningPlatformDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LearningPlatformDbContext") 
    ?? throw new InvalidOperationException("Connection string 'LearningPlatformDbContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();
// app.MapStaticAssets();
app.MapRazorPages();

app.Run();
