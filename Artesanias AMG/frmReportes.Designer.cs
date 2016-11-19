namespace Artesanias_AMG
{
    partial class frmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpFecha = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.grpProducto = new System.Windows.Forms.GroupBox();
            this.cbxProductos = new System.Windows.Forms.ComboBox();
            this.chkProducto = new System.Windows.Forms.CheckBox();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grpFecha.SuspendLayout();
            this.grpProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(13, 13);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(551, 303);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // grpFecha
            // 
            this.grpFecha.Controls.Add(this.dtpDate);
            this.grpFecha.Location = new System.Drawing.Point(13, 323);
            this.grpFecha.Name = "grpFecha";
            this.grpFecha.Size = new System.Drawing.Size(248, 174);
            this.grpFecha.TabIndex = 1;
            this.grpFecha.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(7, 33);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(12, 502);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(56, 17);
            this.chkFecha.TabIndex = 2;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // grpProducto
            // 
            this.grpProducto.Controls.Add(this.cbxProductos);
            this.grpProducto.Location = new System.Drawing.Point(327, 323);
            this.grpProducto.Name = "grpProducto";
            this.grpProducto.Size = new System.Drawing.Size(237, 173);
            this.grpProducto.TabIndex = 3;
            this.grpProducto.TabStop = false;
            // 
            // cbxProductos
            // 
            this.cbxProductos.FormattingEnabled = true;
            this.cbxProductos.Location = new System.Drawing.Point(6, 35);
            this.cbxProductos.Name = "cbxProductos";
            this.cbxProductos.Size = new System.Drawing.Size(121, 21);
            this.cbxProductos.TabIndex = 0;
            // 
            // chkProducto
            // 
            this.chkProducto.AutoSize = true;
            this.chkProducto.Location = new System.Drawing.Point(327, 502);
            this.chkProducto.Name = "chkProducto";
            this.chkProducto.Size = new System.Drawing.Size(69, 17);
            this.chkProducto.TabIndex = 4;
            this.chkProducto.Text = "Producto";
            this.chkProducto.UseVisualStyleBackColor = true;
            this.chkProducto.CheckedChanged += new System.EventHandler(this.chkProducto_CheckedChanged);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(489, 579);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(75, 23);
            this.btnTerminar.TabIndex = 5;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(408, 579);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(327, 579);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 614);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.chkProducto);
            this.Controls.Add(this.grpProducto);
            this.Controls.Add(this.chkFecha);
            this.Controls.Add(this.grpFecha);
            this.Controls.Add(this.chart);
            this.Name = "frmReportes";
            this.Text = "Artesanias AMG - Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grpFecha.ResumeLayout(false);
            this.grpProducto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox grpFecha;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.CheckBox chkProducto;
        private System.Windows.Forms.ComboBox cbxProductos;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnActualizar;
    }
}