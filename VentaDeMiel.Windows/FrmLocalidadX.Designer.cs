namespace VentaDeMiel.Windows
{
    partial class FrmLocalidadX
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
            this.PaisPanel = new System.Windows.Forms.Panel();
            this.ProvinciaPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CiudadPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PaisPanel
            // 
            this.PaisPanel.BackColor = System.Drawing.Color.Transparent;
            this.PaisPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PaisPanel.Location = new System.Drawing.Point(503, 91);
            this.PaisPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PaisPanel.Name = "PaisPanel";
            this.PaisPanel.Size = new System.Drawing.Size(218, 120);
            this.PaisPanel.TabIndex = 13;
            this.PaisPanel.Click += new System.EventHandler(this.PaisPanel_Paint);
            // 
            // ProvinciaPanel
            // 
            this.ProvinciaPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProvinciaPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProvinciaPanel.Location = new System.Drawing.Point(268, 91);
            this.ProvinciaPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProvinciaPanel.Name = "ProvinciaPanel";
            this.ProvinciaPanel.Size = new System.Drawing.Size(218, 120);
            this.ProvinciaPanel.TabIndex = 12;
            this.ProvinciaPanel.Click += new System.EventHandler(this.ProvinciaPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(664, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 47);
            this.panel1.TabIndex = 14;
            this.panel1.Click += new System.EventHandler(this.panel1_Paint);
            // 
            // CiudadPanel
            // 
            this.CiudadPanel.BackColor = System.Drawing.Color.Transparent;
            this.CiudadPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CiudadPanel.Location = new System.Drawing.Point(31, 91);
            this.CiudadPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CiudadPanel.Name = "CiudadPanel";
            this.CiudadPanel.Size = new System.Drawing.Size(218, 120);
            this.CiudadPanel.TabIndex = 11;
            this.CiudadPanel.Click += new System.EventHandler(this.CiudadPanel_Paint);
            // 
            // FrmLocalidadX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.localidad;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(752, 238);
            this.Controls.Add(this.PaisPanel);
            this.Controls.Add(this.ProvinciaPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CiudadPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(752, 238);
            this.MinimumSize = new System.Drawing.Size(752, 238);
            this.Name = "FrmLocalidadX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLocalidadX";
            this.Load += new System.EventHandler(this.FrmLocalidadX_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PaisPanel;
        private System.Windows.Forms.Panel ProvinciaPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel CiudadPanel;
    }
}