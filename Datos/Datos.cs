using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static readonly Conexion instance = new Conexion();

        private string connectionString = "Data Source=ISMAEL-MSI-PULS;Initial Catalog = GestionInventario; Integrated Security = True";

        private Conexion() { }

        public static Conexion Instance
        {
            get
            {
                return instance;
            }
        }

        public void Conectar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected successfully.");
            }
        }

        public void Desconectar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Close();
                Console.WriteLine("Disconnected successfully.");
            }
        }
        //hecho

        public void InsertarProducto(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_InsertarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", codigoProducto);
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@precioVenta", precioVenta);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.ExecuteNonQuery();
            }

        }
        //hecho
        public DataTable SeleccionarProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarProductos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        //hecho
        public void ActualizarProducto(int idProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@precioVenta", precioVenta);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.ExecuteNonQuery();
            }
        }
        //hecho
        public DataTable SeleccionarProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        //hecho
        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_EliminarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.ExecuteNonQuery();
            }
        }
        //hecho
        public DataTable SeleccionarProductoNombre(string nombreProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarProductoNombre", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable ActualizarInventario(int idProducto, int cantidadProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SPActualizarInventario", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void AgregarVenta(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_InsertarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", codigoProducto);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@totalVentas", precioVenta);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.ExecuteNonQuery();
            }

        }
        public void InsertarVenta(int idCliente, int idProducto, DateTime fechaVenta, int totalVentas, int cantidadProducto, int idFactura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarVenta", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@fechaVenta", fechaVenta);
                command.Parameters.AddWithValue("@totalVentas", totalVentas);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@idFactura", idFactura);
                command.ExecuteNonQuery();
            }
        }
    }
}

