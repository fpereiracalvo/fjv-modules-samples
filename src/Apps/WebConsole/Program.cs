using CommandPrompt.Web;
using Fjv.Modules.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebConsole.Commons;
using WebConsole.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();


builder.Services.AddMvc();

builder.Services.AddModuleFactory(typeof(Startup).Assembly);

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddSignalR();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapHub<ConsoleHub>("/consolehub");

app.Run();
