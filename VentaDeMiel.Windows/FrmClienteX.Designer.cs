namespace VentaDeMiel.Windows
{
    partial class FrmClienteX
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TipoDocumentoPanel = new System.Windows.Forms.Panel();
            this.ClientePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(662, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 50);
            this.panel1.TabIndex = 10;
            this.panel1.Click += new System.EventHandler(this.panel1_Paint);
            // 
            // TipoDocumentoPanel
            // 
            this.TipoDocumentoPanel.BackColor = System.Drawing.Color.Transparent;
            this.TipoDocumentoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TipoDocumentoPanel.Location = new System.Drawing.Point(399, 91);
            this.TipoDocumentoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoDocumentoPanel.Name = "TipoDocumentoPanel";
            this.TipoDocumentoPanel.Size = new System.Drawing.Size(317, 128);
            this.TipoDocumentoPanel.TabIndex = 9;
            this.TipoDocumentoPanel.Click += new System.EventHandler(this.TipoDocumentoPanel_Paint);
            // 
            // ClientePanel
            // 
            this.ClientePanel.BackColor = System.Drawing.Color.Transparent;
            this.ClientePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientePanel.Location = new System.Drawing.Point(33, 91);
            this.ClientePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClientePanel.Name = "ClientePanel";
            this.ClientePanel.Size = new System.Drawing.Size(317, 128);
            this.ClientePanel.TabIndex = 8;
            this.ClientePanel.Click += new System.EventHandler(this.ClientePanel_Paint);
            // 
            // FrmClienteX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.Cliente;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(752, 238);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TipoDocumentoPanel);
            this.Controls.Add(this.ClientePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(752, 238);
            this.MinimumSize = new System.Drawing.Size(752, 238);
            this.Name = "FrmClienteX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClienteX";
            this.Load += new System.EventHandler(this.FrmClienteX_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TipoDocumentoPanel;
        private System.Windows.Forms.Panel ClientePanel;
    }
}