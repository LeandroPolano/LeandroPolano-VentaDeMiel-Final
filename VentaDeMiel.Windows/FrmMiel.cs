using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaDeMiel.Windows
{
    public partial class Miel : Form
    {
        public Miel()
        {
            InitializeComponent();
        }

        private void FrmMiel_Load(object sender, EventArgs e)
        {

        }

        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BtnAgregarMiel_Click(object sender, EventArgs e)
        {
            FrmTiposDocumentosAE frm = new FrmTiposDocumentosAE();
            frm.Text = "Agregar Miel";
            DialogResult dr = frm.ShowDialog(this);
        }

        private void KGws_Click(object sender, EventArgs e)
        {

        }
    }
}
