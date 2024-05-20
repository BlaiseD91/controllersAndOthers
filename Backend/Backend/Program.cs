using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Backend.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BackendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BackendContext") ?? throw new InvalidOperationException("Connection string 'BackendContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b=>b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();

/*
 STEPS

 1. Modellek létrehozása
 2. Controllerek létrehozása )scaffolded item -> api controller with entity actions using entity framework
 3. A weatherforecats példa kitörlése
 4. A Program.cs-be useCors sor
 5. Ahol idegen kulcs van a táblában, ott kell a controllerekbe belerakni a getekhez az Include és where dolgokat
 6. Ha kell akkor az adatbetöltést rakjuk belée a context fájlba (Data mappa)
 7. PKG manager: Add-Migration init, Script-Migration
 8. PKG managerrel felrakjuk: EntityFrameworkCore, ...Tools, ...Core.SqLite
 9. PKG console-ban: update-database
 10. ha szükséges a lekéréseknél belenyúlunk kicsit a visszaadott responsokba
 */

