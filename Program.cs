using System.Text.Json.Serialization;
using AppColl.Data.Providers;
using AppColl.Data.State;
using AppColl.Serialization.Csv;
using AppColl.Serialization.Json;
using AppColl.Serialization.Xml;
using AppColl.Services;
using AppColl.Sessions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<BroadbandSession>();
builder.Services.AddScoped<BroadbandService>();

builder.Services.AddSingleton<BroadbandCsvSerializer>();
builder.Services.AddSingleton<BroadbandJsonSerializer>();
builder.Services.AddSingleton<BroadbandXmlSerializer>();

builder.Services.AddHttpClient<IBroadbandDataProvider, BroadbandCsvDataProvider>();
builder.Services.AddSingleton<IBroadbandStateStore, InMemoryBroadbandStateStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();