using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2TrabajoFinal.Formularios
{
    public partial class formProductos : Form
    {
        public formProductos()
        {
            InitializeComponent();
            LoadTheme();

            dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            lblListado.ForeColor = ThemeColor.SecondaryColor;

        }

        private void lblProveedor_Click(object sender, EventArgs e)
        {

        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigoProducto, cantidadProducto;
            decimal precioVenta;

            if (!int.TryParse(txtCodigo.Text, out codigoProducto))
            {
                MessageBox.Show("El código de producto debe ser un número entero válido.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out cantidadProducto))
            {
                MessageBox.Show("La cantidad debe ser un número entero válido.");
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("El precio de venta debe ser un número decimal válido.");
                return;
            }

            Negocio.Negocio.Instance.InsertarProducto(codigoProducto, txtNombreProducto.Text, txtDescripcion.Text, cantidadProducto, precioVenta, txtProveedor.Text);

            txtCodigo.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecioVenta.Text = "";
            txtProveedor.Text = "";

            MessageBox.Show("Producto Insertado");
            dgvProductos.Refresh();

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBusquedaCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idProducto;
            bool esNumero = int.TryParse(txtBuscador.Text, out idProducto);

            if (cbFiltro.Text == "Nombre")
            {
                dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProductoNombre(txtBuscador.Text);
            }
            else if (esNumero)
            {
                dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProducto(idProducto);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido para el filtro por ID.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProducto;
            bool esNumero = int.TryParse(txtBuscador.Text, out idProducto);

            if (esNumero)
            {
                Negocio.Negocio.Instance.EliminarProducto(idProducto);
                MessageBox.Show("Producto eliminado correctamente.");
                dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido para el filtro por ID.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            

        }
    }
}
