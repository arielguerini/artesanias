using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artesanias_AMG
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
            this.chkFecha.Checked = true;
            this.chkProducto.Checked = false;
            this.chkFecha.Location = new Point(grpFecha.Location.X + 13, grpFecha.Location.Y - 1);
            this.chkProducto.Location = new Point(grpProducto.Location.X + 13, grpProducto.Location.Y - 1);
            validarSelecciones();
            llenarCombo();
            refreshChart(Reports.getSalesByDate(this.dtpDate.Value.ToShortDateString()), "Total");
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

        private void validarSelecciones()
        {
            if (this.chkFecha.Checked == false)
                grpFecha.Enabled = false;
            else
                grpFecha.Enabled = true;

            if (this.chkProducto.Checked == false)
                grpProducto.Enabled = false;
            else
                grpProducto.Enabled = true;

        }

        private void refreshChart(DataTable dt, string seriesName)
        { //esto no anda
            chart.Series.Clear();
            chart.DataSource = dt;
            chart.Series.Add(seriesName);
            chart.Series[seriesName].XValueMember = "Nombre";
            chart.Series[seriesName].YValueMembers = "Cantidad";
            //chart.Series[seriesName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //chart.DataBind();
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            validarSelecciones();
        }

        private void chkProducto_CheckedChanged(object sender, EventArgs e)
        {
            validarSelecciones();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            refreshChart(Reports.getSalesByDate(this.dtpDate.Value.ToShortDateString()), this.dtpDate.Value.ToShortDateString());
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
