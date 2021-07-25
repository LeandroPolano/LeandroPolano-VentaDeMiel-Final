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
    public partial class FrmEnvaseX : Form
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
        public FrmEnvaseX()
        {
            InitializeComponent();
        }

        private void FrmEnvaseX_Load(object sender, EventArgs e)
        {

        }
        Point formPosition;
        Boolean mouseAction;
        private void CapacidadPanel_Paint(object sender, EventArgs e)
        {
            FrmCapacidades frm = new FrmCapacidades();
            frm.ShowDialog(this);
        }

        private void TipoDeEnvasePanel_Paint(object sender, EventArgs e)
        {
            FrmTiposEnvases frm = new FrmTiposEnvases();
            frm.ShowDialog(this);
        }

        private void panel1_Paint(object sender, EventArgs e)
        {
            Close();
        }
    }
}
