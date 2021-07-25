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
    public partial class Menu : Form
    {
        Point formPosition;
        Boolean mouseAction;
        public Menu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void Menu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void VentaPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ProveedorPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ColmenarPanel_MouseClick(object sender, MouseEventArgs e)
        {
            FrmColmenares frm = new FrmColmenares();
            frm.ShowDialog(this);
        }

        private void InsumoPanel_MouseClick(object sender, MouseEventArgs e)
        {
            FrmInsumos frm = new FrmInsumos();
            frm.ShowDialog(this);
        }

        private void VentaPanel_MouseClick(object sender, MouseEventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.ShowDialog(this);
        }

        private void ProveedorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.ShowDialog(this);
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmClientesDeMiel frm = new FrmClientesDeMiel();
            frm.ShowDialog(this);
        }

        private void ProblemasDeColmenas_Click(object sender, EventArgs e)
        {
            FrmEstadosColmenas frm = new FrmEstadosColmenas();
            frm.ShowDialog(this);
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog(this);
        }

        private void tipoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposDeProductos frm = new FrmTiposDeProductos();
            frm.ShowDialog(this);
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcas frm = new FrmMarcas();
            frm.ShowDialog(this);
        }

        private void ciudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCiudades frm = new FrmCiudades();
            frm.ShowDialog(this);
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.ShowDialog(this);
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPaises frm = new FrmPaises();
            frm.ShowDialog(this);

        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMiel frm = new FrmMiel();
            frm.ShowDialog(this);
        }

        private void tiposDeEnvasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposEnvases frm = new FrmTiposEnvases();
            frm.ShowDialog(this);
        }

        private void capacidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCapacidades frm = new FrmCapacidades();
            frm.ShowDialog(this);
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
