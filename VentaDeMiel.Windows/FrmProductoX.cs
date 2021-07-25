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
    public partial class FrmProductoX : Form
    {
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
        public FrmProductoX()
        {
            InitializeComponent();
        }
        Point formPosition;
        Boolean mouseAction;
        private void FrmProductoX_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, EventArgs e)
        {
            FrmMarcas frm = new FrmMarcas();
            frm.ShowDialog(this);
        }

        private void panel2_Paint(object sender, EventArgs e)
        {
            FrmTiposDeProductos frm = new FrmTiposDeProductos();
            frm.ShowDialog(this);
        }

        private void TipoDeEnvasePanel_Paint(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog(this);
        }
    }
}
