namespace VentaDeMiel.Windows
{
    partial class FrmProveedores
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
            this.CmlRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlCuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlCodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BorrarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CerrarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.NuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
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
            this.CmlRazonSocial,
            this.CmlCuit,
            this.CmlDireccion,
            this.CmlCiudad,
            this.CmlCodigoPostal,
            this.CmlTelefono,
            this.CmlEmail});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 67);
            this.DatosDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.RowHeadersWidth = 62;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(946, 383);
            this.DatosDataGridView.TabIndex = 13;
            // 
            // CmlRazonSocial
            // 
            this.CmlRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlRazonSocial.HeaderText = "Razon Social";
            this.CmlRazonSocial.MinimumWidth = 8;
            this.CmlRazonSocial.Name = "CmlRazonSocial";
            this.CmlRazonSocial.ReadOnly = true;
            // 
            // CmlCuit
            // 
            this.CmlCuit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlCuit.HeaderText = "Cuit";
            this.CmlCuit.MinimumWidth = 8;
            this.CmlCuit.Name = "CmlCuit";
            this.CmlCuit.ReadOnly = true;
            // 
            // CmlDireccion
            // 
            this.CmlDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlDireccion.HeaderText = "Direccion";
            this.CmlDireccion.MinimumWidth = 8;
            this.CmlDireccion.Name = "CmlDireccion";
            this.CmlDireccion.ReadOnly = true;
            // 
            // CmlCiudad
            // 
            this.CmlCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlCiudad.HeaderText = "Ciudad";
            this.CmlCiudad.MinimumWidth = 8;
            this.CmlCiudad.Name = "CmlCiudad";
            this.CmlCiudad.ReadOnly = true;
            // 
            // CmlCodigoPostal
            // 
            this.CmlCodigoPostal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlCodigoPostal.HeaderText = "Codigo Postal";
            this.CmlCodigoPostal.MinimumWidth = 8;
            this.CmlCodigoPostal.Name = "CmlCodigoPostal";
            this.CmlCodigoPostal.ReadOnly = true;
            // 
            // CmlTelefono
            // 
            this.CmlTelefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlTelefono.HeaderText = "Telefono";
            this.CmlTelefono.MinimumWidth = 8;
            this.CmlTelefono.Name = "CmlTelefono";
            this.CmlTelefono.ReadOnly = true;
            // 
            // CmlEmail
            // 
            this.CmlEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlEmail.HeaderText = "Email";
            this.CmlEmail.MinimumWidth = 8;
            this.CmlEmail.Name = "CmlEmail";
            this.CmlEmail.ReadOnly = true;
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
            this.toolStrip1.Size = new System.Drawing.Size(946, 67);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
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
            // FrmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 450);
            this.ControlBox = false;
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1086, 506);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(946, 450);
            this.MinimumSize = new System.Drawing.Size(946, 450);
            this.Name = "FrmProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton NuevoToolStripButton;
        private System.Windows.Forms.ToolStripButton BorrarToolStripButton;
        private System.Windows.Forms.ToolStripButton EditarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CerrarToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlCuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlCodigoPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlEmail;
    }
}