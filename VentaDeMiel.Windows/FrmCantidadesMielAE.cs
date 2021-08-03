using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaDeMiel.BusinessLayer.Entities;
using VentaDeMiel.ServiceLayer.Servicios;

namespace VentaDeMiel.Windows
{
    public partial class FrmCantidadesMielAE : Form
    {
        public FrmCantidadesMielAE()
        {
            InitializeComponent();
        }

        public FrmCantidadesMielAE(FrmCantidadesMiel frmCantidadesMiel)
        {
            this.frm = frmCantidadesMiel;
            InitializeComponent();

        }

        internal void SetCantidadMiel(CantidadMiel cantidadMiel)
        {
            this.cantidadMiel = cantidadMiel;
        }
        decimal cantidad = 0;
        internal decimal GetCantidadMiel()
        {
            return cantidad = decimal.Parse(TextBoxCantidadMiel.Text);

        }

        private void FrmCantidadesMielAE_Load(object sender, EventArgs e)
        {

        }
        private CantidadMiel cantidadMiel;
        private bool _esEdicion = false;
        private ServicioCantidadMiel _servicio = new ServicioCantidadMiel();
        private FrmCantidadesMiel frmCantidadesMiel;
        private readonly FrmCantidadesMiel frm;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cantidadMiel == null)
                {
                    cantidadMiel = new CantidadMiel();
                }

                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            cantidad = decimal.Parse(TextBoxCantidadMiel.Text);
                            _servicio.Guardar(cantidad);
                            if (frm != null)
                            {
                                frm.AgregarFila(cantidadMiel);

                            }
                            MessageBox.Show("Registro Guardado");
                            DialogResult dr = MessageBox.Show("¿Desea dar de alta otro registro?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                InicializarControles();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }

                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }

            }
        }

        private void InicializarControles()
        {
            TextBoxCantidadMiel.Clear();
            TextBoxCantidadMiel.Focus();
            cantidadMiel = null;
        }

        private bool ValidarObjeto()
        {
           

            return true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cantidadMiel != null)
            {
                TextBoxCantidadMiel.Text = cantidadMiel.cantidadMiel.ToString();
                _esEdicion = true;
            }
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxCantidadMiel.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxCantidadMiel.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidadMiel, "Debe ingresar una cantidadMiel");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
