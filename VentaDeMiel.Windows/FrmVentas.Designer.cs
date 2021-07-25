namespace VentaDeMiel.Windows
{
    partial class FrmVentas
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
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.CmnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoPanel = new System.Windows.Forms.Panel();
            this.CerrarPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CmnVenta,
            this.CmnCliente,
            this.CmnFecha,
            this.CmnTotal});
            this.DatosDataGridView.Location = new System.Drawing.Point(73, 8);
            this.DatosDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.RowHeadersWidth = 62;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(863, 537);
            this.DatosDataGridView.TabIndex = 15;
            // 
            // CmnVenta
            // 
            this.CmnVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnVenta.HeaderText = "Numero Venta";
            this.CmnVenta.MinimumWidth = 8;
            this.CmnVenta.Name = "CmnVenta";
            this.CmnVenta.ReadOnly = true;
            // 
            // CmnCliente
            // 
            this.CmnCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnCliente.HeaderText = "Cliente";
            this.CmnCliente.MinimumWidth = 8;
            this.CmnCliente.Name = "CmnCliente";
            this.CmnCliente.ReadOnly = true;
            // 
            // CmnFecha
            // 
            this.CmnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnFecha.HeaderText = "Fecha";
            this.CmnFecha.MinimumWidth = 8;
            this.CmnFecha.Name = "CmnFecha";
            this.CmnFecha.ReadOnly = true;
            // 
            // CmnTotal
            // 
            this.CmnTotal.HeaderText = "Total";
            this.CmnTotal.MinimumWidth = 8;
            this.CmnTotal.Name = "CmnTotal";
            this.CmnTotal.ReadOnly = true;
            this.CmnTotal.Width = 150;
            // 
            // NuevoPanel
            // 
            this.NuevoPanel.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.sell_stock_40px;
            this.NuevoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NuevoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NuevoPanel.Location = new System.Drawing.Point(6, 13);
            this.NuevoPanel.Name = "NuevoPanel";
            this.NuevoPanel.Size = new System.Drawing.Size(60, 54);
            this.NuevoPanel.TabIndex = 16;
            this.NuevoPanel.Click += new System.EventHandler(this.NuevoPanel_Paint);
            // 
            // CerrarPanel
            // 
            this.CerrarPanel.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.exit_40px;
            this.CerrarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CerrarPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CerrarPanel.Location = new System.Drawing.Point(6, 73);
            this.CerrarPanel.Name = "CerrarPanel";
            this.CerrarPanel.Size = new System.Drawing.Size(60, 54);
            this.CerrarPanel.TabIndex = 17;
            this.CerrarPanel.Click += new System.EventHandler(this.CerrarPanel_Click);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(947, 555);
            this.ControlBox = false;
            this.Controls.Add(this.CerrarPanel);
            this.Controls.Add(this.NuevoPanel);
            this.Controls.Add(this.DatosDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(947, 555);
            this.MinimumSize = new System.Drawing.Size(947, 555);
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.FrmVentas_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnTotal;
        private System.Windows.Forms.Panel NuevoPanel;
        private System.Windows.Forms.Panel CerrarPanel;
    }
}