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
    public partial class FrmClienteX : Form
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
        public FrmClienteX()
        {
            InitializeComponent();
        }

        private void FrmClienteX_Load(object sender, EventArgs e)
        {

        }
        Point formPosition;
        Boolean mouseAction;
        private void TipoDocumentoPanel_Paint(object sender, EventArgs e)
        {
            FrmMiel frm = new FrmMiel();
            frm.ShowDialog(this);
        }

        private void ClientePanel_Paint(object sender, EventArgs e)
        {
            FrmClientesDeMiel frm = new FrmClientesDeMiel();
            frm.ShowDialog(this);
        }

        private void panel1_Paint(object sender, EventArgs e)
        {
            Close();
        }
    }
}
