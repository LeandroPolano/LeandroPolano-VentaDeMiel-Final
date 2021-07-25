namespace VentaDeClase.ReportLayer
{
    partial class FrmMenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProblemasDeColmenas = new System.Windows.Forms.ToolStripMenuItem();
            this.colmenaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsbMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.insumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsbTiposDeProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.capacidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsbColmenas = new System.Windows.Forms.ToolStripMenuItem();
            this.TsbProvincias = new System.Windows.Forms.ToolStripMenuItem();
            this.ciudadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoEnvaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteDeMielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Goldenrod;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 38);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProblemasDeColmenas,
            this.colmenaresToolStripMenuItem,
            this.TsbMarca,
            this.insumosToolStripMenuItem,
            this.tipoToolStripMenuItem,
            this.TsbTiposDeProductos,
            this.capacidadToolStripMenuItem,
            this.TsbColmenas,
            this.TsbProvincias,
            this.ciudadesToolStripMenuItem,
            this.toolStripSeparator1,
            this.productosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.tipoEnvaseToolStripMenuItem,
            this.clienteDeMielToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.archivosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(103, 32);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // ProblemasDeColmenas
            // 
            this.ProblemasDeColmenas.Name = "ProblemasDeColmenas";
            this.ProblemasDeColmenas.Size = new System.Drawing.Size(300, 36);
            this.ProblemasDeColmenas.Text = "Estados De Colmenas";
            this.ProblemasDeColmenas.Click += new System.EventHandler(this.Colmenas_Click);
            // 
            // colmenaresToolStripMenuItem
            // 
            this.colmenaresToolStripMenuItem.Name = "colmenaresToolStripMenuItem";
            this.colmenaresToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.colmenaresToolStripMenuItem.Text = "Colmenares";
            this.colmenaresToolStripMenuItem.Click += new System.EventHandler(this.colmenaresToolStripMenuItem_Click);
            // 
            // TsbMarca
            // 
            this.TsbMarca.Name = "TsbMarca";
            this.TsbMarca.Size = new System.Drawing.Size(300, 36);
            this.TsbMarca.Text = "Marcas";
            this.TsbMarca.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // insumosToolStripMenuItem
            // 
            this.insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            this.insumosToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.insumosToolStripMenuItem.Text = "Insumos";
            this.insumosToolStripMenuItem.Click += new System.EventHandler(this.insumosToolStripMenuItem_Click);
            // 
            // tipoToolStripMenuItem
            // 
            this.tipoToolStripMenuItem.Name = "tipoToolStripMenuItem";
            this.tipoToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.tipoToolStripMenuItem.Text = "TiposDocumentos";
            this.tipoToolStripMenuItem.Click += new System.EventHandler(this.tipoToolStripMenuItem_Click);
            // 
            // TsbTiposDeProductos
            // 
            this.TsbTiposDeProductos.Name = "TsbTiposDeProductos";
            this.TsbTiposDeProductos.Size = new System.Drawing.Size(300, 36);
            this.TsbTiposDeProductos.Text = "TiposDeProductos";
            this.TsbTiposDeProductos.Click += new System.EventHandler(this.TsbTiposDeProductos_Click);
            // 
            // capacidadToolStripMenuItem
            // 
            this.capacidadToolStripMenuItem.Name = "capacidadToolStripMenuItem";
            this.capacidadToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.capacidadToolStripMenuItem.Text = "Capacidades";
            this.capacidadToolStripMenuItem.Click += new System.EventHandler(this.capacidadToolStripMenuItem_Click);
            // 
            // TsbColmenas
            // 
            this.TsbColmenas.Name = "TsbColmenas";
            this.TsbColmenas.Size = new System.Drawing.Size(300, 36);
            this.TsbColmenas.Text = "Paises";
            this.TsbColmenas.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // TsbProvincias
            // 
            this.TsbProvincias.Name = "TsbProvincias";
            this.TsbProvincias.Size = new System.Drawing.Size(300, 36);
            this.TsbProvincias.Text = "Provincias";
            this.TsbProvincias.Click += new System.EventHandler(this.TsbProvincias_Click);
            // 
            // ciudadesToolStripMenuItem
            // 
            this.ciudadesToolStripMenuItem.Name = "ciudadesToolStripMenuItem";
            this.ciudadesToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.ciudadesToolStripMenuItem.Text = "Ciudades";
            this.ciudadesToolStripMenuItem.Click += new System.EventHandler(this.ciudadesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(297, 6);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click_1);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // tipoEnvaseToolStripMenuItem
            // 
            this.tipoEnvaseToolStripMenuItem.Name = "tipoEnvaseToolStripMenuItem";
            this.tipoEnvaseToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.tipoEnvaseToolStripMenuItem.Text = "TipoEnvase";
            this.tipoEnvaseToolStripMenuItem.Click += new System.EventHandler(this.tipoEnvaseToolStripMenuItem_Click);
            // 
            // clienteDeMielToolStripMenuItem
            // 
            this.clienteDeMielToolStripMenuItem.Name = "clienteDeMielToolStripMenuItem";
            this.clienteDeMielToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.clienteDeMielToolStripMenuItem.Text = "ClienteDeMiel";
            this.clienteDeMielToolStripMenuItem.Click += new System.EventHandler(this.clienteDeMielToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(66, 32);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.aaaa;
            this.ClientSize = new System.Drawing.Size(800, 384);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProblemasDeColmenas;
        private System.Windows.Forms.ToolStripMenuItem TsbMarca;
        private System.Windows.Forms.ToolStripMenuItem TsbTiposDeProductos;
        private System.Windows.Forms.ToolStripMenuItem TsbColmenas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsbProvincias;
        private System.Windows.Forms.ToolStripMenuItem capacidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciudadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colmenaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoEnvaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteDeMielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
    }
}