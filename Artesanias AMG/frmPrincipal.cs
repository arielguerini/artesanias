using System;
using System.Windows.Forms;

namespace Artesanias_AMG
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProducto FormProducto = new frmProducto();
            FormProducto.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas FormVentas = new frmVentas();
            FormVentas.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReportes FormReportes = new frmReportes();
            FormReportes.Show();
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            BD.closeConnection();
            Program.endApp();
        }
    }
}
