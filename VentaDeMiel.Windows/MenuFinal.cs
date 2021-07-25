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
    public partial class MenuFinal : Form
    {
        Point formPosition;
        Boolean mouseAction;
        public MenuFinal()
        {
            InitializeComponent();
        }

        private void ColmenarPanel_Paint(object sender, EventArgs e)
        {
            FrmColmenares frm = new FrmColmenares();
            frm.ShowDialog(this);
        }

        private void InsumoPanel_Paint(object sender, EventArgs e)
        {
            FrmInsumos frm = new FrmInsumos();
            frm.ShowDialog(this);
        }

        private void EstadoColmenaPanel_Paint(object sender, EventArgs e)
        {
            FrmEstadosColmenas frm = new FrmEstadosColmenas();
            frm.ShowDialog(this);
        }

        private void EnvasesPanel_Paint(object sender, EventArgs e)
        {
            FrmEnvaseX frm = new FrmEnvaseX();
            frm.ShowDialog(this);
        }

        private void LocalidadPanel_Paint(object sender, EventArgs e)
        {
            FrmLocalidadX frm = new FrmLocalidadX();
            frm.ShowDialog(this);
        }

        private void ProductoPanel_Paint(object sender, EventArgs e)
        {
            FrmProductoX frm = new FrmProductoX();
            frm.ShowDialog(this);
        }

        private void VentasPanel_Paint(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.ShowDialog(this);
        }

        private void ProveedorPanel_Paint(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.ShowDialog(this);
        }

        private void ClientePanel_Paint(object sender, EventArgs e)
        {
            FrmClienteX frm = new FrmClienteX();
            frm.ShowDialog(this);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        
        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void MenuFinal_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void MenuFinal_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        private void MenuFinal_Load(object sender, EventArgs e)
        {
        }

        private void ClientePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CompraInsumoPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void CompraInsumoPanel_MouseClick(object sender, MouseEventArgs e)
        {
            FrmComprasInsumos frm = new FrmComprasInsumos();
            frm.ShowDialog(this);
        }
    }
}
