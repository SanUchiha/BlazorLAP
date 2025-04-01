using BlazorLAP.Components;
using BlazorLAP.Configurations;
using BlazorLAP.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IServiceCollection services = builder.Services;
string? connection = configuration.GetConnectionString("LAPCloud");

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

services.AddRazorComponents().AddInteractiveServerComponents();
services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
//services.AddScoped<ICampusRepository, ICampusRepository>();

services.AddCors(options =>
{
    options.AddPolicy("CORS",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseCors("CORS");
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
