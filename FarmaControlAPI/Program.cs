using FarmaControlAPI.Data;
using FarmaControlAPI.Repository;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Otros servicios
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddScoped<IUsuarioRepository<Usuario>, UserRepository>();
builder.Services.AddScoped<IEmpleadoRepository<Empleado>, EmlpeadoRepository>();
builder.Services.AddScoped<IProveedorRepository<Proveedor>, ProveedorRepository>();
builder.Services.AddScoped<IOrdenCompraRepository<OrdenCompra>, OrdenCompraRepository>();
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

