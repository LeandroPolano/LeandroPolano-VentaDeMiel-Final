using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaDeMiel.Windows;

namespace VentaDeClase.ReportLayer
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

       

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPaises frm = new FrmPaises();
            frm.ShowDialog(this);
        }

        private void Colmenas_Click(object sender, EventArgs e)
        {
            FrmEstadosColmenas frm = new FrmEstadosColmenas();
            frm.ShowDialog(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            this.Close();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcas frm = new FrmMarcas();
            frm.ShowDialog(this);
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMiel frm = new FrmMiel();
            frm.ShowDialog(this);
        }

        private void TsbTiposDeProductos_Click(object sender, EventArgs e)
        {
            FrmTiposDeProductos frm = new FrmTiposDeProductos();
            frm.ShowDialog(this);
        }

        private void TsbProvincias_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.ShowDialog(this);
        }

        private void capacidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCapacidades frm = new FrmCapacidades();
            frm.ShowDialog(this);
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCiudades frm = new FrmCiudades();
            frm.ShowDialog(this);
        }

        private void colmenaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmColmenares frm = new FrmColmenares();
            frm.ShowDialog(this);
        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog(this);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.ShowDialog(this);
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInsumos frm = new FrmInsumos();
            frm.ShowDialog(this);
        }

        private void tipoEnvaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposEnvases frm = new FrmTiposEnvases();
            frm.ShowDialog(this);
        }

        private void clienteDeMielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesDeMiel frm = new FrmClientesDeMiel();
            frm.ShowDialog(this);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.ShowDialog(this);
        }
    }
}
