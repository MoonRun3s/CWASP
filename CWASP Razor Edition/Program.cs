﻿using CWASP_Razor_Edition.Data;
using CWASP_Razor_Edition.Hubs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR().AddAzureSignalR();
builder.Services.AddDbContext<CWASP_Razor_EditionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CWASPdbconnection") ?? throw new InvalidOperationException("Connection string 'CWASPdbconnection' not found.")));
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://cwasp.azurewebsites.net")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});


var app = builder.Build();

/* Database seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.MapRazorPages();
app.MapHub<ControlHub>("/Hubs/controlHub");

app.Run();
