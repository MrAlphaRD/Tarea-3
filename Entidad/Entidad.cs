using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
    public class Compra
    {
        public int IdCompra { get; set; }
        public int? IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public decimal? PrecioCompra { get; set; }
        public string Proveedor { get; set; }
        public string ContactoProveedor { get; set; }
        public DateTime? FechaCompra { get; set; }
    }
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int CantidadProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Proveedor { get; set; }
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Admin { get; set; }
    }
    public class Venta
    {
        public int IdCliente { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public int TotalVentas { get; set; }
        public int CantidadProducto { get; set; }
        public int IdFactura { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
