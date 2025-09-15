using Cooperadora2025.Server.Client.Pages;
using Cooperadora2025.Server.Components;
using Cooperadora2025.BD.Datos;
using Microsoft.EntityFrameworkCore;

// Configura el contructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);
#region configura el Constructor de la aplicacion y sus servicios

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
              ?? throw new InvalidOperationException("El string de conexion no existe.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

#endregion

// Contruccion de la aplicacion
var app = builder.Build();
#region Contruccion de la aplicacion y área de middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Cooperadora2025.Server.Client._Imports).Assembly);

app.MapControllers();

#endregion

app.Run();
