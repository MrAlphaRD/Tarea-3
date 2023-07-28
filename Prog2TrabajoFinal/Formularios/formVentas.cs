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
    public partial class formVentas : Form
    {
        public formVentas()
        {
            InitializeComponent();
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

        private void formVentas_Load(object sender, EventArgs e)
        {

        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Negocio.Negocio.Instance.SeleccionarProducto(Convert.ToInt32(txtBuscador.Text));
                txtCodigo.Text = a.Rows[0]["idProducto"].ToString();
                txtNombreProducto.Text = a.Rows[0]["nombreProducto"].ToString();
                txtPrecioVenta.Text = a.Rows[0]["precioVenta"].ToString();
            }
            catch (Exception r)
            {
                MessageBox.Show("El campo esta vacio o no existe");
            }
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
                MessageBox.Show("La cantidad de producto debe ser un número entero válido.");
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("El precio de venta debe ser un número decimal válido.");
                return;
            }

            dgvVentas.Rows.Add(codigoProducto, txtNombreProducto.Text, cantidadProducto, precioVenta);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = txtCodigo.Text;
                var b = txtNombreProducto.Text;
                var c = Convert.ToInt32(txtCantidad.Text);
                var d = Convert.ToInt32(txtPrecioVenta.Text);
                var Total = c * d;
                txtBuscador.Text = "";

                // Obtener la DataView actual del DataGridView

                DataView dataView = dgvVentas.DataSource as DataView;



                // Si la DataView es nula, crear una nueva y definir las columnas

                if (dataView == null)

                {

                    DataTable table = new DataTable();

                    table.Columns.Add("Código", typeof(string));

                    table.Columns.Add("Nombre", typeof(string));

                    table.Columns.Add("Cantidad", typeof(int));

                    table.Columns.Add("Precio", typeof(int));

                    table.Columns.Add("Total", typeof(int));

                    dataView = new DataView(table);

                    dgvVentas.DataSource = dataView;

                }



                // Crear una nueva fila y agregar los valores a, b, c, d y Total a la fila

                DataRowView row = dataView.AddNew();

                row["Código"] = a;

                row["Nombre"] = b;

                row["Cantidad"] = c;

                row["Precio"] = d;

                row["Total"] = Total;



                // Mostrar la DataView en el DataGridView

                dgvVentas.DataSource = dataView;


                // Sumar los totales y mostrar el resultado en el TextBox

                int sum = 0;

                foreach (DataRowView r in dataView)

                {
                    sum += Convert.ToInt32(r["Total"]);
                }

                txtTotal.Text = sum.ToString();



                txtBuscador.Text = "";

                txtCantidad.Text = "";

                txtCodigo.Text = "";

                txtNombreProducto.Text = "";

                txtPrecioVenta.Text = "";





            }
            catch (Exception r)
            {
                MessageBox.Show("El campo esta vacio o no existe");
            }
        }


        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistroVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    var idCliente = Convert.ToInt32(txtCliente.Text);
                    var codigoProducto = Convert.ToInt32(row.Cells["Código"].Value);
                    var cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    // var total = Convert.ToInt32(row.Cells["Total"].Value);
                    var total = Convert.ToInt32(txtTotal.Text);
                    var idfactura = Convert.ToInt32(txtFactura.Text);
                    var fechaF = fecha.Value;


                    Negocio.Negocio.Instance.InsertarVenta(idCliente, codigoProducto, cantidad, total, fechaF, idfactura);
                }
                MessageBox.Show("Venta realizada con exito");
            }

            catch (Exception r)
            {
                MessageBox.Show("Campos Erroneos");
            }
        }
    }
}

