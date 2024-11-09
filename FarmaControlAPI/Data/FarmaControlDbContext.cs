using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace FarmaControlAPI.Models
{
    public class FarmaControlDbContext: DbContext
    {
        public DbSet<Client> Clientes { get; set; }  
        public DbSet<CategoriaProducto> CategoriaProductos { get; set; } 
        public DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }  
        public DbSet<DetalleOrdenVenta> DetalleOrdenVentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<OrdenCompra> OrdenCompras { get; set; }
        public DbSet<OrdenVenta> OrdenVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public FarmaControlDbContext(DbContextOptions<FarmaControlDbContext> options) : base(options) { }

    }
}
