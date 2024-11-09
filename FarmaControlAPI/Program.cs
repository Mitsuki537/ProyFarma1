using FarmaControlAPI;
using FarmaControlAPI.Data;
using FarmaControlAPI.Models;
using FarmaControlAPI.Repository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos con autenticación de Windows
builder.Services.AddDbContext<FarmaControlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();

// Registro de Repository<T> como Scoped
builder.Services.AddScoped(typeof(Repository<>));

// Otros servicios
builder.Services.AddSingleton<DatabaseConnection>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

