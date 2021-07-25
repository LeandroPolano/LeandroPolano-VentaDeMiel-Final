
namespace VentaDeMiel.Windows
{
    partial class FrmComprasInsumos
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
            this.CerrarPanel = new System.Windows.Forms.Panel();
            this.NuevoPanel = new System.Windows.Forms.Panel();
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.CmnProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CerrarPanel
            // 
            this.CerrarPanel.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.exit_40px;
            this.CerrarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CerrarPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CerrarPanel.Location = new System.Drawing.Point(12, 72);
            this.CerrarPanel.Name = "CerrarPanel";
            this.CerrarPanel.Size = new System.Drawing.Size(70, 55);
            this.CerrarPanel.TabIndex = 20;
            this.CerrarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CerrarPanel_Paint);
            this.CerrarPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CerrarPanel_MouseClick);
            // 
            // NuevoPanel
            // 
            this.NuevoPanel.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.sell_stock_40px;
            this.NuevoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NuevoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NuevoPanel.Location = new System.Drawing.Point(12, 12);
            this.NuevoPanel.Name = "NuevoPanel";
            this.NuevoPanel.Size = new System.Drawing.Size(70, 54);
            this.NuevoPanel.TabIndex = 19;
            this.NuevoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NuevoPanel_Paint);
            this.NuevoPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NuevoPanel_MouseClick);
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CmnProveedor,
            this.CmnFecha,
            this.CmnTotal});
            this.DatosDataGridView.Location = new System.Drawing.Point(101, 12);
            this.DatosDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.RowHeadersWidth = 62;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(705, 425);
            this.DatosDataGridView.TabIndex = 18;
            // 
            // CmnProveedor
            // 
            this.CmnProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnProveedor.HeaderText = "Proveedor";
            this.CmnProveedor.MinimumWidth = 8;
            this.CmnProveedor.Name = "CmnProveedor";
            this.CmnProveedor.ReadOnly = true;
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
            // FrmComprasInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.ControlBox = false;
            this.Controls.Add(this.CerrarPanel);
            this.Controls.Add(this.NuevoPanel);
            this.Controls.Add(this.DatosDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmComprasInsumos";
            this.Text = "FrmComprasInsumos";
            this.Load += new System.EventHandler(this.FrmComprasInsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CerrarPanel;
        private System.Windows.Forms.Panel NuevoPanel;
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnTotal;
    }
}