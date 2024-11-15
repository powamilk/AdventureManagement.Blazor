using AdventureManager.Blaor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AdventureManagement.BUS;
using Microsoft.EntityFrameworkCore;
using AdventureManagement.DAL;
using AdventureManagement.BUS.Mapper;
using MudBlazor.Services;
using AdventureManagement.BUS.Services.Interface;
using AdventureManagement.BUS.Services.Implement;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=powa;Database=AdventureManagement;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddTransient<IAdventureService, AdventureService>();
builder.Services.AddTransient<IGuideService, GuideService>();
builder.Services.AddTransient<IOrganismService, OrganismService>();
builder.Services.AddTransient<IParticipantService, ParticipantService>();
builder.Services.AddTransient<IParticipantInteractionService, ParticipantInteractionService>();
builder.Services.AddAutoMapper(typeof(Mapping));
//builder.Services.AddMudServices();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
