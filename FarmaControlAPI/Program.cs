using FarmaControlAPI.Data;
using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SharedModels;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT en el formato: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


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


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

