using AdventureManagement.BUS.Mapper;
using AdventureManagement.BUS.Services;
using AdventureManagement.DAL;
using AdventureManagement.PL;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer("Server=powa;Database=AdventureManagement;Trusted_Connection=True;TrustServerCertificate=True"));
////"Server=powa;Database=AdventureManagement;Trusted_Connection=True;TrustServerCertificate=True"

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("")));
builder.Services.AddTransient<IAdventureService, AdventureService>();
builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
