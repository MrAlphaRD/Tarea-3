using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public sealed class Negocio
    {

        private static readonly Lazy<Negocio> lazy = new Lazy<Negocio>(() => new Negocio());

        public static Negocio Instance { get { return lazy.Value; } }

        private Negocio() { }
        public void InsertarProducto(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            Conexion.Instance.Conectar();
            Conexion.Instance.InsertarProducto(codigoProducto, nombreProducto, descripcion, cantidadProducto, precioVenta, proveedor);
            Conexion.Instance.Desconectar();

        }

        public DataTable SeleccionarProductos()
        {
            Conexion.Instance.Conectar();
            return Conexion.Instance.SeleccionarProductos();
        }
        

        public DataTable SeleccionarProducto(int codigoProducto)
        {
            Conexion.Instance.Conectar();
            return Conexion.Instance.SeleccionarProducto(codigoProducto);

        }
        public DataTable SeleccionarProductoNombre(string nombreProducto)
        {
            Conexion.Instance.Conectar();
            return Conexion.Instance.SeleccionarProductoNombre(nombreProducto);
        }

        public void ActualizarProducto(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            Conexion.Instance.Conectar();
            Conexion.Instance.ActualizarProducto(codigoProducto, nombreProducto, descripcion, cantidadProducto, precioVenta, proveedor);
            Conexion.Instance.Desconectar();
        }

        public void EliminarProducto(int codigoProducto)
        {
            Conexion.Instance.Conectar();
            Conexion.Instance.EliminarProducto(codigoProducto);
            Conexion.Instance.Desconectar();
        }
        public void ActualizarInventario(int codigoProducto, int cantidadProducto)
        {
            Conexion.Instance.Conectar();
            Conexion.Instance.ActualizarInventario(codigoProducto, cantidadProducto);
            Conexion.Instance.Desconectar();
        }
        public void InsertarVenta(int idCliente, int codigoProducto, int cantidad,  int totalVenta, DateTime fechaVenta, int idFactura)
        {   
            Conexion.Instance.Conectar();
            Conexion.Instance.InsertarVenta(idCliente, codigoProducto, fechaVenta, totalVenta,cantidad,idFactura );
            Conexion.Instance.Desconectar();
        }

    }
}
