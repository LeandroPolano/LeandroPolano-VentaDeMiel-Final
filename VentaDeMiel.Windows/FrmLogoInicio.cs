using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaDeClase.ReportLayer;

namespace VentaDeMiel.Windows
{
    public partial class FrmLogoInicio : Form
    {
        public FrmLogoInicio()
        {
            InitializeComponent();
        }
        private void FrmLogoInicio_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            //Application.Exit();

            
        }

        private void FrmLogoInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            while (this.Opacity > 0)
            {
                this.Opacity -= 0.00001;
            }
            this.Hide();
            Menu FM = new Menu();
            FM.Show();
            timer1.Stop();

        }
    }
}
