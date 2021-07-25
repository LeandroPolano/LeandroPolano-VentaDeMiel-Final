namespace VentaDeMiel.Windows
{
    partial class FrmClientesDeMiel
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
            this.CmlDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlCodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmlNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
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
            this.CmlDireccion,
            this.CmlCiudad,
            this.CmlCodigoPostal,
            this.CmlTelefono,
            this.CmlEmail,
            this.CmlTipoDocumento,
            this.CmlNumeroDocumento});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 67);
            this.DatosDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.RowHeadersWidth = 62;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(1317, 300);
            this.DatosDataGridView.TabIndex = 15;
            // 
            // CmlRazonSocial
            // 
            this.CmlRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlRazonSocial.HeaderText = "Razon Social";
            this.CmlRazonSocial.MinimumWidth = 8;
            this.CmlRazonSocial.Name = "CmlRazonSocial";
            this.CmlRazonSocial.ReadOnly = true;
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
            // CmlTipoDocumento
            // 
            this.CmlTipoDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlTipoDocumento.HeaderText = "Tipo de Documento";
            this.CmlTipoDocumento.MinimumWidth = 8;
            this.CmlTipoDocumento.Name = "CmlTipoDocumento";
            this.CmlTipoDocumento.ReadOnly = true;
            // 
            // CmlNumeroDocumento
            // 
            this.CmlNumeroDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CmlNumeroDocumento.HeaderText = "Numero de Documento";
            this.CmlNumeroDocumento.MinimumWidth = 8;
            this.CmlNumeroDocumento.Name = "CmlNumeroDocumento";
            this.CmlNumeroDocumento.ReadOnly = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1317, 67);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::VentaDeMiel.Windows.Properties.Resources.Add;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(56, 64);
            this.toolStripButton1.Text = "Nuevo";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.NuevoToolStripButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::VentaDeMiel.Windows.Properties.Resources.delete_document_40px;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(54, 64);
            this.toolStripButton2.Text = "Borrar";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.BorrarToolStripButton_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::VentaDeMiel.Windows.Properties.Resources.edit_40px;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 64);
            this.toolStripButton3.Text = "Editar";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.EditarToolStripButton_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::VentaDeMiel.Windows.Properties.Resources.exit_40px;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(53, 64);
            this.toolStripButton4.Text = "Cerrar";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Click += new System.EventHandler(this.CerrarToolStripButton_Click);
            // 
            // FrmClientesDeMiel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 367);
            this.ControlBox = false;
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1335, 414);
            this.MinimumSize = new System.Drawing.Size(1335, 414);
            this.Name = "FrmClientesDeMiel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientesDeMiel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlCodigoPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmlNumeroDocumento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}