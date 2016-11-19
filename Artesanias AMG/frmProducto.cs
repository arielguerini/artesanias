using System;
using System.Windows.Forms;

namespace Artesanias_AMG
{
    public partial class frmProducto : Form
    {
        private Producto aux = null;

        public frmProducto()
        {
            InitializeComponent();
        }

        #region Botones

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //verificar que el producto no contenga ninguna venta asociada, caso contrario no se deberia borrar.

            if (controlEliminar(Program.listaProductos[dgv1.CurrentRow.Index]))
            {
                if (Program.eliminarProducto(aux))
                {
                    dgv1.DataSource = Program.listaProductos;
                    dgv1.Refresh();
                }
            }
            else
                MessageBox.Show("El producto tiene ventas asociadas. \nElimine primero las ventas de este producto para poder eliminarlo.", "Atencion", MessageBoxButtons.OK);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Program.agregarProducto(txtNombre.Text, txtDescripcion.Text, float.Parse(txtCosto.Text), float.Parse(txtPrecio.Text));
            Program.refreshProductList();
            dgv1.DataSource = Program.listaProductos;
            dgv1.Refresh();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarSeleccion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region Metodos
        private void llenarSeleccion(Producto producto)
        {
            this.txt_Id.Text = producto.Id.ToString();
            this.txtNombre.Text = producto.Nombre;
            this.txtDescripcion.Text = producto.Descripcion;
            this.txtCosto.Text = producto.Costo.ToString();
            this.txtPrecio.Text = producto.Precio.ToString();
        }

        private void limpiarSeleccion()
        {
            this.txt_Id.Text = "";
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";
            this.txtCosto.Text = "";
            this.txtPrecio.Text = "";
            txt_Id.Focus();
        }

        private bool controlEliminar(Producto producto)
        {
            bool flag = false;
            foreach (Venta ventafor in Program.listaVentas)
            {
                if (ventafor.Product_Id == producto.Id)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        #endregion

        #region Eventos

        private void Principal_Load(object sender, EventArgs e)
        {
            Program.refreshProductList();
            dgv1.DataSource = Program.listaProductos;
            dgv1.Refresh();
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            if (Program.listaProductos.Count > 0)
            {
                int indice = dgv1.CurrentRow.Index;
                aux = Program.listaProductos[indice];
                llenarSeleccion(aux);
            }

        }
        #endregion


    }
}
