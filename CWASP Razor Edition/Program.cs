using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CWASP_Razor_Edition.Data;
using CWASP_Razor_Edition.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CWASP_Razor_EditionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CWASP_Razor_EditionContext") ?? throw new InvalidOperationException("Connection string 'CWASP_Razor_EditionContext' not found.")));
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
