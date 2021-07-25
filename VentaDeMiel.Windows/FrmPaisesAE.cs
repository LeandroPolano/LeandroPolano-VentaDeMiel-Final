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
    public partial class FrmPaisesAE : Form
    {
        private FrmPaises frmPais;

        public FrmPaisesAE()
        {
            InitializeComponent();
        }

        public FrmPaisesAE(FrmPaises frmPais)
        {
            this.frm = frmPais;
            InitializeComponent();
        }
        private Pais pais;
        private bool _esEdicion = false;
        private ServicioPais _servicio = new ServicioPais();
        private FrmPaises frmPaises;
        private readonly FrmPaises frm;
        private void FrmPaisAE_Load(object sender, EventArgs e)
        {

        }

        internal void SetPais(Pais pais)
        {
            this.pais = pais;
        }

        internal Pais GetPais()
        {
            return pais;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                TextBoxPais.Text = pais.pais;
                _esEdicion = true;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new Pais();
                }

                pais.pais = TextBoxPais.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(pais);
                            if (frm != null)
                            {
                                frm.AgregarFila(pais);

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
            TextBoxPais.Clear();
            TextBoxPais.Focus();
            pais = null;
        }

        private bool ValidarObjeto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(pais))
            {
                valido = false;
                errorProvider1.SetError(TextBoxPais, "Pais repetido");
            }

            return valido;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxPais.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxPais.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxPais, "Debe ingresar un Pais");
            }

            return valido;
        }
    }
}
