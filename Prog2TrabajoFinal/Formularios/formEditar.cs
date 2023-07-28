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
    public partial class formEditar : Form
    {
        public formEditar()
        {
            InitializeComponent();
            dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
            LoadTheme();
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

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Negocio.Negocio.Instance.SeleccionarProducto(Convert.ToInt32(txtBuscador.Text));
                txtCodigo.Text = a.Rows[0]["idProducto"].ToString();
                txtNombreProducto.Text = a.Rows[0]["nombreProducto"].ToString();
                txtDescripcion.Text = a.Rows[0]["descripcion"].ToString();
                txtCantidad.Text = a.Rows[0]["cantidadProducto"].ToString();
                txtPrecioVenta.Text = a.Rows[0]["precioVenta"].ToString();
                txtProveedor.Text = a.Rows[0]["proveedor"].ToString();
            }
            catch (Exception r)
            {
                MessageBox.Show("El campo esta vacio o no existe");

            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.Negocio.Instance.ActualizarProducto(Convert.ToInt32(txtCodigo.Text), txtNombreProducto.Text, txtDescripcion.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtPrecioVenta.Text), txtProveedor.Text);
                txtCodigo.Text = "";
                txtNombreProducto.Text = "";
                txtDescripcion.Text = "";
                txtCantidad.Text = "";
                txtPrecioVenta.Text = "";
                txtProveedor.Text = "";
                txtBuscador.Text = "";
                MessageBox.Show("Producto Actualizado");
            }
            catch
            {
                MessageBox.Show("No debe dejar espacios vacios");
            }
        }

        private void formEditar_Load(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
        }
    }
}
