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
    public partial class FrmMielAE : Form
    {
        public FrmMielAE()
        {
            InitializeComponent();
        }

        public FrmMielAE(FrmMiel frmTiposDocumentos)
        {
            this.frm = frmTiposDocumentos;
            InitializeComponent();
        }



        private void TextBoxTipoDocumento_TextChanged(object sender, EventArgs e)
        {

        }
        private bool _esEdicion = false;
        private ServicioMiel _servicio = new ServicioMiel();
        VentaDeMiel.BusinessLayer.Entities.Miel miel;
        private readonly FrmMiel frm;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (miel == null)
                {
                    miel = new BusinessLayer.Entities.Miel();
                }
                
                miel.miel=decimal.Parse( TextBoxMiel.Text);
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(miel);
                            if (frm != null)
                            {
                               // frm.AgregarFila(miel);

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

        private bool ValidarObjeto()
        {
            throw new NotImplementedException();
        }

        private void InicializarControles()
        {
            TextBoxMiel.Clear();
            TextBoxMiel.Focus();
            miel = null;
        }

        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (miel != null)
            {
                TextBoxMiel.Text = miel.miel.ToString();
                _esEdicion = true;
            }
        }


        private void TextBoxMarca_TextChanged(object sender, EventArgs e)
        {

        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TextBoxMiel.Text) ||
                string.IsNullOrWhiteSpace(TextBoxMiel.Text))
            {
                valido = false;
                errorProvider1.SetError(TextBoxMiel, "Debe ingresar un Tipo de documento");
            }

            return valido;
        }

        internal BusinessLayer.Entities.Miel GetMiel()
        {
            return miel;
        }

        internal void SetTipoDocumento(BusinessLayer.Entities.Miel tipodocumento)
        {
            this.miel = tipodocumento;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
