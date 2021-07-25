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
    public partial class FrmLocalidadX : Form
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
        public FrmLocalidadX()
        {
            InitializeComponent();
        }
        Point formPosition;
        Boolean mouseAction;
        private void FrmLocalidadX_Load(object sender, EventArgs e)
        {

        }

        private void PaisPanel_Paint(object sender, EventArgs e)
        {
            FrmPaises frm = new FrmPaises();
            frm.ShowDialog(this);

        }

        private void ProvinciaPanel_Paint(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.ShowDialog(this);
        }

        private void CiudadPanel_Paint(object sender, EventArgs e)
        {
            FrmCiudades frm = new FrmCiudades();
            frm.ShowDialog(this);
        }

        private void panel1_Paint(object sender, EventArgs e)
        {
            Close();
        }
    }
}
