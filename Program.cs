using Arvefordeleren.Components;
using Arvefordeleren.Data;
using Arvefordeleren.Models.Repositories;
using Arvefordeleren.Services;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddHttpClient();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<AssetsRepository>();
builder.Services.AddScoped<HeirsRepository>();
builder.Services.AddScoped<TestatorRepository>();
builder.Services.AddScoped<CSVExporter>();
builder.Services.AddScoped<CSVImporter>();
builder.Services.AddScoped<TestatorService>();
builder.Services.AddScoped<ValidationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UsePathBase("/home");


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();