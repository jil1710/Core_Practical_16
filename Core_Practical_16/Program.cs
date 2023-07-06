using Core_Practical_16;
using Microsoft.Extensions.Logging.Configuration;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddLogging(option =>
{
    option.ClearProviders();
    option.AddConfiguration(builder.Configuration.GetSection("Loggin")).AddConsole();

    // If App is in Debug mode then Log in Debug console
    #if DEBUG
        option.AddDebug();
    #endif
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseMyLoggerMiddleWare();
// I have created custom middleware that can handle every request and log the message of every request
// To check Uncomment below

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
