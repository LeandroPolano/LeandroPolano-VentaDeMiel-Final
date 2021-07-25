namespace VentaDeMiel.Windows
{
    partial class FrmEnvaseX
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
            this.TipoDeEnvasePanel = new System.Windows.Forms.Panel();
            this.CapacidadPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TipoDeEnvasePanel
            // 
            this.TipoDeEnvasePanel.BackColor = System.Drawing.Color.Transparent;
            this.TipoDeEnvasePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TipoDeEnvasePanel.Location = new System.Drawing.Point(32, 91);
            this.TipoDeEnvasePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoDeEnvasePanel.Name = "TipoDeEnvasePanel";
            this.TipoDeEnvasePanel.Size = new System.Drawing.Size(317, 120);
            this.TipoDeEnvasePanel.TabIndex = 5;
            this.TipoDeEnvasePanel.Click += new System.EventHandler(this.TipoDeEnvasePanel_Paint);
            // 
            // CapacidadPanel
            // 
            this.CapacidadPanel.BackColor = System.Drawing.Color.Transparent;
            this.CapacidadPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CapacidadPanel.Location = new System.Drawing.Point(400, 91);
            this.CapacidadPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CapacidadPanel.Name = "CapacidadPanel";
            this.CapacidadPanel.Size = new System.Drawing.Size(317, 120);
            this.CapacidadPanel.TabIndex = 6;
            this.CapacidadPanel.Click += new System.EventHandler(this.CapacidadPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(662, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 47);
            this.panel1.TabIndex = 7;
            this.panel1.Click += new System.EventHandler(this.panel1_Paint);
            // 
            // FrmEnvaseX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VentaDeMiel.Windows.Properties.Resources.Envase;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(752, 238);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CapacidadPanel);
            this.Controls.Add(this.TipoDeEnvasePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(752, 238);
            this.MinimumSize = new System.Drawing.Size(752, 238);
            this.Name = "FrmEnvaseX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEnvaseX";
            this.Load += new System.EventHandler(this.FrmEnvaseX_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TipoDeEnvasePanel;
        private System.Windows.Forms.Panel CapacidadPanel;
        private System.Windows.Forms.Panel panel1;
    }
}