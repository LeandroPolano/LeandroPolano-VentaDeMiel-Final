namespace VentaDeMiel.Windows
{
    partial class FrmColmenares
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
            this.CmnColmenar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnCantidadColmena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnEstadoColmenar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnCantidadInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BorrarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CerrarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CmnColmenar,
            this.CmnCiudad,
            this.CmnCantidadColmena,
            this.CmnEstadoColmenar,
            this.CmnInsumo,
            this.CmnCantidadInsumo});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 67);
            this.DatosDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.RowHeadersWidth = 62;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(937, 427);
            this.DatosDataGridView.TabIndex = 11;
            // 
            // CmnColmenar
            // 
            this.CmnColmenar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnColmenar.HeaderText = "Nombre Colmenar";
            this.CmnColmenar.MinimumWidth = 8;
            this.CmnColmenar.Name = "CmnColmenar";
            this.CmnColmenar.ReadOnly = true;
            // 
            // CmnCiudad
            // 
            this.CmnCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnCiudad.HeaderText = "Ciudad";
            this.CmnCiudad.MinimumWidth = 8;
            this.CmnCiudad.Name = "CmnCiudad";
            this.CmnCiudad.ReadOnly = true;
            // 
            // CmnCantidadColmena
            // 
            this.CmnCantidadColmena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnCantidadColmena.HeaderText = "Colmenas";
            this.CmnCantidadColmena.MinimumWidth = 8;
            this.CmnCantidadColmena.Name = "CmnCantidadColmena";
            this.CmnCantidadColmena.ReadOnly = true;
            // 
            // CmnEstadoColmenar
            // 
            this.CmnEstadoColmenar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnEstadoColmenar.HeaderText = "Estado de colmenas";
            this.CmnEstadoColmenar.MinimumWidth = 8;
            this.CmnEstadoColmenar.Name = "CmnEstadoColmenar";
            this.CmnEstadoColmenar.ReadOnly = true;
            // 
            // CmnInsumo
            // 
            this.CmnInsumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmnInsumo.HeaderText = "Insumo";
            this.CmnInsumo.MinimumWidth = 8;
            this.CmnInsumo.Name = "CmnInsumo";
            this.CmnInsumo.ReadOnly = true;
            // 
            // CmnCantidadInsumo
            // 
            this.CmnCantidadInsumo.HeaderText = "Cantidad De Insumo";
            this.CmnCantidadInsumo.MinimumWidth = 6;
            this.CmnCantidadInsumo.Name = "CmnCantidadInsumo";
            this.CmnCantidadInsumo.ReadOnly = true;
            this.CmnCantidadInsumo.Width = 125;
            // 
            // NuevoToolStripButton
            // 
            this.NuevoToolStripButton.Image = global::VentaDeMiel.Windows.Properties.Resources.Add;
            this.NuevoToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoToolStripButton.Name = "NuevoToolStripButton";
            this.NuevoToolStripButton.Size = new System.Drawing.Size(56, 64);
            this.NuevoToolStripButton.Text = "Nuevo";
            this.NuevoToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NuevoToolStripButton.Click += new System.EventHandler(this.NuevoToolStripButton_Click);
            // 
            // BorrarToolStripButton
            // 
            this.BorrarToolStripButton.Image = global::VentaDeMiel.Windows.Properties.Resources.delete_document_40px;
            this.BorrarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BorrarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorrarToolStripButton.Name = "BorrarToolStripButton";
            this.BorrarToolStripButton.Size = new System.Drawing.Size(54, 64);
            this.BorrarToolStripButton.Text = "Borrar";
            this.BorrarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BorrarToolStripButton.Click += new System.EventHandler(this.BorrarToolStripButton_Click);
            // 
            // EditarToolStripButton
            // 
            this.EditarToolStripButton.Image = global::VentaDeMiel.Windows.Properties.Resources.edit_40px;
            this.EditarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditarToolStripButton.Name = "EditarToolStripButton";
            this.EditarToolStripButton.Size = new System.Drawing.Size(52, 64);
            this.EditarToolStripButton.Text = "Editar";
            this.EditarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EditarToolStripButton.Click += new System.EventHandler(this.EditarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 67);
            // 
            // CerrarToolStripButton
            // 
            this.CerrarToolStripButton.Image = global::VentaDeMiel.Windows.Properties.Resources.exit_40px;
            this.CerrarToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CerrarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CerrarToolStripButton.Name = "CerrarToolStripButton";
            this.CerrarToolStripButton.Size = new System.Drawing.Size(53, 64);
            this.CerrarToolStripButton.Text = "Cerrar";
            this.CerrarToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CerrarToolStripButton.Click += new System.EventHandler(this.CerrarToolStripButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoToolStripButton,
            this.BorrarToolStripButton,
            this.EditarToolStripButton,
            this.toolStripSeparator1,
            this.CerrarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(937, 67);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FrmColmenares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 494);
            this.ControlBox = false;
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(937, 494);
            this.MinimumSize = new System.Drawing.Size(937, 494);
            this.Name = "FrmColmenares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colmenares";
            this.Load += new System.EventHandler(this.FrmColmenares_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnColmenar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnCantidadColmena;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnEstadoColmenar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnCantidadInsumo;
        private System.Windows.Forms.ToolStripButton NuevoToolStripButton;
        private System.Windows.Forms.ToolStripButton BorrarToolStripButton;
        private System.Windows.Forms.ToolStripButton EditarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CerrarToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}