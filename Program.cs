using System.Text.Json.Serialization;
using AppCollRider.DataSources;
using AppCollRider.Services;
using AppCollRider.State;

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

builder.Services.AddScoped<BroadbandService>();
builder.Services.AddHttpClient<IBroadbandDataSource, BroadbandCsvDataSource>();
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