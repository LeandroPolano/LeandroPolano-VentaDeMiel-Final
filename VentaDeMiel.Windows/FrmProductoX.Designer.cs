namespace VentaDeMiel.Windows
{
    partial class FrmProductoX
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
            this.ProductoPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TipoDeProductoPanel = new System.Windows.Forms.Panel();
            this.MarcaPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ProductoPanel
            // 
            this.ProductoPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProductoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductoPanel.Location = new System.Drawing.Point(31, 91);
            this.ProductoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProductoPanel.Name = "ProductoPanel";
            this.ProductoPanel.Size = new System.Drawing.Size(218, 120);
            this.ProductoPanel.TabIndex = 8;
            this.ProductoPanel.Click += new System.EventHandler(this.TipoDeEnvasePanel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(664, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 47);
            this.panel1.TabIndex = 10;
            this.panel1.Click += new System.EventHandler(this.panel1_Paint);
            // 
            // TipoDeProductoPanel
            // 
            this.TipoDeProductoPanel.BackColor = System.Drawing.Color.Transparent;
            this.TipoDeProductoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TipoDeProductoPanel.Location = new System.Drawing.Point(268, 91);
            this.TipoDeProductoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoDeProductoPanel.Name = "TipoDeProductoPanel";
            this.TipoDeProductoPanel.Size = new System.Drawing.Size(218, 120);
            this.TipoDeProductoPanel.TabIndex = 9;
            this.TipoDeProductoPanel.Click += new System.EventHandler(this.panel2_Paint);
            // 
            // MarcaPanel
            // 
            this.MarcaPanel.BackColor = System.Drawing.Color.Transparent;
            this.MarcaPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MarcaPanel.Location = new System.Drawing.Point(503, 91);
            this.MarcaPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MarcaPanel.Name = "MarcaPanel";
            this.MarcaPanel.Size = new System.Drawing.Size(218, 120);
            this.MarcaPanel.TabIndex = 10;
            this.MarcaPanel.Click += new System.EventHandler(this.panel3_Paint);
            // 
            // FrmProductoX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.producto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(752, 238);
            this.Controls.Add(this.MarcaPanel);
            this.Controls.Add(this.TipoDeProductoPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductoPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(752, 238);
            this.MinimumSize = new System.Drawing.Size(752, 238);
            this.Name = "FrmProductoX";
            this.Text = "FrmProductoX";
            this.Load += new System.EventHandler(this.FrmProductoX_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ProductoPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TipoDeProductoPanel;
        private System.Windows.Forms.Panel MarcaPanel;
    }
}