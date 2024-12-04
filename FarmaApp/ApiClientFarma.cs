using FarmaApp.Repository;
using SharedModels;
using SharedModels.Dtos.CategoriaProducto;
using SharedModels.Dtos.Cliente;
using SharedModels.Dtos.DetalleOrdenCompra;
using SharedModels.Dtos.DetalleOrdenVenta;
using SharedModels.Dtos.Empleado;
using SharedModels.Dtos.Inventario;
using SharedModels.Dtos.MovimientoInventario;
using SharedModels.Dtos.OrdenCompra;
using SharedModels.Dtos.OrdenVenta;
using SharedModels.Dtos.Producto;
using SharedModels.Dtos.Proveedor;
using SharedModels.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FarmaApp
{
    public class ApiClientFarma
    {
        private readonly HttpClient _httpClient;
        public IRepository<UsuarioDto> Usuario { get; }
        public IRepository<EmpleadoDto> Empleados { get; }
        public IRepository<ProductoDto> Productos { get; }
        public IRepository<OrdenVentaDto> OrdenesVenta { get; }
        public IRepository<OrdenCompraDto> OrdenesCompra { get; }
        public IRepository<ClienteDto> Clientes { get; }
        public IRepository<CategoriaProductoDto> CategoriasProducto { get; }
        public IRepository<ProveedorDto> Proveedores {  get; }
        public IRepository<DetalleOrdenVentaDto> DetallesOrdenVenta { get; }
        public IRepository<DetalleOrdenCompraDto> DetallesOrdenCompra { get; }
        public IRepository<InventorioDto> Inventarios { get; }
        public IRepository<MovimientoInventarioDto> Movimientos { get; }
        public ApiClientFarma(string jwtToken)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", jwtToken)
                }
            };

            Usuario = new UsuarioRepository<UsuarioDto>(_httpClient, "api/Usuario");  
            Empleados = new EmpleadoRepository<EmpleadoDto>(_httpClient, "api/Empleado");
            Productos = new UsuarioRepository<ProductoDto>(_httpClient, "api/Producto");
            OrdenesVenta = new UsuarioRepository<OrdenVentaDto>(_httpClient, "api/OrdenVenta");
            OrdenesCompra = new UsuarioRepository<OrdenCompraDto>(_httpClient, "api/OrdenCompra");
            Clientes = new UsuarioRepository<ClienteDto>(_httpClient, "api/Cliente");
            CategoriasProducto = new CategoriaRepository<CategoriaProductoDto>(_httpClient, "api/CategoriaProducto");
            Proveedores = new ProveedorRepository<ProveedorDto>(_httpClient, "api/Proveedor");
            DetallesOrdenVenta = new UsuarioRepository<DetalleOrdenVentaDto>(_httpClient, "api/DetalleOrdenVenta");
            DetallesOrdenCompra = new UsuarioRepository<DetalleOrdenCompraDto>(_httpClient, "api/DetalleOrdenCompra");
            Inventarios = new UsuarioRepository<InventorioDto>(_httpClient, "api/Inventario");
            Movimientos = new UsuarioRepository<MovimientoInventarioDto>(_httpClient, "api/Movimiento");
        }
    }
}
