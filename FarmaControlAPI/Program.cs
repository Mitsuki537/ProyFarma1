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
builder.Services.AddScoped<IDetalleOrdenCompraRepository<DetalleOrdenCompra>, DetalleOrdenCompraRepository>();
builder.Services.AddScoped<ICategoriaProductoRepository<CategoriaProducto>, CategoriaProductoRepository>();
builder.Services.AddScoped<IInventarioRepository<Inventario>, InventarioRepository>();
builder.Services.AddScoped<IProductoRepository<Producto>, ProductoRepository>();
builder.Services.AddScoped<IInventorioMovimientoRepository<Movimiento>, InventarioMovimientoRepository>();
builder.Services.AddScoped<ICLienteRepository<Client>, ClienteRepository>();
builder.Services.AddScoped<IOrdenVentaRepository<OrdenVenta>, OrdenVentaRepository>();
builder.Services.AddScoped<IDetalleOrdenVentaRepository<DetalleOrdenVenta>, DetalleOrdenVentaRepository>();

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

