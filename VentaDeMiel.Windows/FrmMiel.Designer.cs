namespace VentaDeMiel.Windows
{
    partial class Miel
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
            this.KGws = new System.Windows.Forms.Label();
            this.BtnAgregarMiel = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KGws
            // 
            this.KGws.AutoSize = true;
            this.KGws.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KGws.Location = new System.Drawing.Point(438, 55);
            this.KGws.Name = "KGws";
            this.KGws.Size = new System.Drawing.Size(41, 25);
            this.KGws.TabIndex = 10;
            this.KGws.Text = "KG";
            this.KGws.Click += new System.EventHandler(this.KGws_Click);
            // 
            // BtnAgregarMiel
            // 
            this.BtnAgregarMiel.Location = new System.Drawing.Point(12, 111);
            this.BtnAgregarMiel.Name = "BtnAgregarMiel";
            this.BtnAgregarMiel.Size = new System.Drawing.Size(131, 51);
            this.BtnAgregarMiel.TabIndex = 12;
            this.BtnAgregarMiel.Text = "Agregar";
            this.BtnAgregarMiel.UseVisualStyleBackColor = true;
            this.BtnAgregarMiel.Click += new System.EventHandler(this.BtnAgregarMiel_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(301, 111);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(131, 51);
            this.BtnCerrar.TabIndex = 13;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(141, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 22);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cantidad De Miel :";
            // 
            // Miel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 174);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnAgregarMiel);
            this.Controls.Add(this.KGws);
            this.Name = "Miel";
            this.Text = "FrmMiel";
            this.Load += new System.EventHandler(this.FrmMiel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label KGws;
        private System.Windows.Forms.Button BtnAgregarMiel;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}