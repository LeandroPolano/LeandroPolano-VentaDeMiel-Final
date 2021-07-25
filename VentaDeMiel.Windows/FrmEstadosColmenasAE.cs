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
    public partial class FrmEstadosColmenasAE : Form
    {
        public FrmEstadosColmenasAE()
        {
            InitializeComponent();
        }

        public FrmEstadosColmenasAE(FrmEstadosColmenas frmEstadosColmenas)
        {
            this.frm = frmEstadosColmenas;
            InitializeComponent();
        }



        private void TextBoxEstadoColmena_TextChanged(object sender, EventArgs e)
        {

        }
        private EstadoColmena estadocolmena;
        private bool _esEdicion = false;
        private ServicioEstadoColmena _servicio = new ServicioEstadoColmena();
        private FrmEstadosColmenas frmEstadosColmenas;

        private readonly FrmEstadosColmenas frm;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (estadocolmena == null)
                {
                    estadocolmena = new EstadoColmena();
                }

                estadocolmena.estadoColmena = TextBoxEstadoColmena.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(estadocolmena);
                            if (frm != null)
                            {
                                frm.AgregarFila(estadocolmena);

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
            TextBoxEstadoColmena.Clear();
            TextBoxEstadoColmena.Focus();
            estadocolmena = null;
        }

        private bool ValidarObjeto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(estadocolmena))
            {
                valido = false;
                errorProvider1.SetError(TextBoxEstadoColmena, "Estado De Colmena repetido");
            }

            return valido;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (estadocolmena != null)
            {
                TextBoxEstadoColmena.Text = estadocolmena.estadoColmena;
                _esEdicion = true;
            }
        }


        private void TextBoxMarca_TextChanged(object sender, EventArgs e)
        {

        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxEstadoColmena.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxEstadoColmena.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxEstadoColmena, "Debe ingresar un Estado De Colmena");
            }

            return valido;
        }

        internal EstadoColmena GetEstadoColmena()
        {
            return estadocolmena;
        }

        internal void SetEstadoColmena(EstadoColmena tipodocumento)
        {
            this.estadocolmena = tipodocumento;
        }

        private void FrmEstadosColmenasAE_Load(object sender, EventArgs e)
        {

        }
    }
}
