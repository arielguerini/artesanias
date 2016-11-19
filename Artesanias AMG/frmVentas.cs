using System;
using System.Windows.Forms;

namespace Artesanias_AMG
{
    public partial class frmVentas : Form
    {

        public frmVentas()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmVentas_Load(object sender, EventArgs e)
        {
            llenarCombo();
            Program.refreshVentaList();
            dgvVentas.DataSource = Operations.getVentasView();
            dgvVentas.Refresh();
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            llenarDatos();
        }

        private void cbxProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxProductos.Items.Count > 0)
                txtPrecio.Text = Program.listaProductos[cbxProductos.SelectedIndex].Precio.ToString();
        }
        #endregion

        #region Metodos

        public bool controlVenta(string paso)
        {
            bool flag = false;
            //verificar si falta algun dato
            if (paso.Equals("primero"))
            {
                if (txtCantidad.Text.Equals("0") || txtCantidad.Text == "")
                {
                    if (txtCantidad.Text.Equals("0"))
                    {
                        MessageBox.Show("Cantidad no puede ser 0", "Atencion", MessageBoxButtons.OK);
                    }
                    if (txtCantidad.Text == "")
                    {
                        MessageBox.Show("Cantidad no puede ser vacio", "Atencion", MessageBoxButtons.OK);
                    }
                }
                else
                    flag = true;
            }
            //verificar que no exista una venta del mismo producto para el mismo dia y el mismo precio
            //verificar que no se modifique el producto creando registros repetidos.
            if (paso.Equals("segundo"))
            {
                if (Program.listaVentas.Count > 0)
                {
                    foreach (Venta ventafor in Program.listaVentas)
                    {

                        if (ventafor.Product_Id == int.Parse(cbxProductos.SelectedValue.ToString()) && ventafor.Date == dtpFecha.Value.ToShortDateString() && ventafor.Price == int.Parse(txtPrecio.Text))
                        {
                            MessageBox.Show("Ya existe una venta para el mismo producto y mismo dia y al mismo precio", "Atencion", MessageBoxButtons.OK);
                            flag = false;
                            break;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        private void llenarCombo()
        {
            //Vaciar comboBox
            cbxProductos.DataSource = null;
            //Asignar la propiedad DataSource
            cbxProductos.DataSource = Program.listaProductos;
            //Indicar qué propiedad se verá en la lista
            cbxProductos.DisplayMember = "Nombre";
            //Indicar qué valor tendrá cada ítem
            cbxProductos.ValueMember = "Id";
        }

        private void llenarDatos()
        {
            dtpFecha.Value = DateTime.Parse(Program.listaVentas[dgvVentas.CurrentRow.Index].Date);
            cbxProductos.SelectedValue = Program.listaVentas[dgvVentas.CurrentRow.Index].Product_Id;
            txtCantidad.Text = Program.listaVentas[dgvVentas.CurrentRow.Index].Amount.ToString();
            txtPrecio.Text = Program.listaVentas[dgvVentas.CurrentRow.Index].Price.ToString();
        }
        #endregion

        #region Botones
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            //si no faltan datos
           if(controlVenta("primero"))
            {
                //no debe haber venta para el mismo dia ni el mismo producto.
                if(controlVenta("segundo"))
                {
                    Program.agregarVenta(Operations.createSell(dtpFecha.Value.ToShortDateString(), int.Parse(cbxProductos.SelectedValue.ToString()), int.Parse(txtCantidad.Text), int.Parse(txtPrecio.Text)));
                    Program.refreshVentaList();
                    dgvVentas.DataSource = Operations.getVentasView();
                    dgvVentas.Refresh();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Program.eliminarVenta(Program.listaVentas[dgvVentas.CurrentRow.Index]))
            {
                Program.refreshVentaList();
                dgvVentas.DataSource = Operations.getVentasView();
                dgvVentas.Refresh();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(controlVenta("segundo"))
            {
                // if precio
                if (txtPrecio.Text != Program.listaVentas[dgvVentas.CurrentRow.Index].Price.ToString())
                {
                    Operations.modifySell(Program.listaVentas[dgvVentas.CurrentRow.Index], "precio", txtPrecio.Text);
                }
                //if fecha
                if (dtpFecha.Value.ToShortDateString() != Program.listaVentas[dgvVentas.CurrentRow.Index].Date)
                {
                    Operations.modifySell(Program.listaVentas[dgvVentas.CurrentRow.Index], "fecha", dtpFecha.Value.ToShortDateString());
                }
                //if producto
                if (cbxProductos.SelectedValue.ToString() != Program.listaVentas[dgvVentas.CurrentRow.Index].Product_Id.ToString())
                {
                    Operations.modifySell(Program.listaVentas[dgvVentas.CurrentRow.Index], "producto", cbxProductos.SelectedValue.ToString());
                }
                //if cantidad
                if (int.Parse(txtCantidad.Text) != Program.listaVentas[dgvVentas.CurrentRow.Index].Amount)
                {
                    Operations.modifySell(Program.listaVentas[dgvVentas.CurrentRow.Index], "cantidad", txtCantidad.Text);
                }
                Program.refreshVentaList();
                dgvVentas.DataSource = Operations.getVentasView();
                dgvVentas.Refresh();
            }
        }
        #endregion

        
    }
}
