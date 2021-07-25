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
    public partial class FrmCapacidadesAE : Form
    {
        public FrmCapacidadesAE()
        {
            InitializeComponent();
        }

        public FrmCapacidadesAE(FrmCapacidades frmCapacidades)
        {
            this.frm = frmCapacidades;
            InitializeComponent();

        }

        internal void SetCapacidad(Capacidad capacidad)
        {
            this.capacidad = capacidad;
        }

        internal Capacidad GetCapacidad()
        {
            return capacidad;
        }

        private void FrmCapacidadesAE_Load(object sender, EventArgs e)
        {

        }
        private Capacidad capacidad;
        private bool _esEdicion = false;
        private ServicioCapacidad _servicio = new ServicioCapacidad();
        private FrmCapacidades frmCapacidades;
        private readonly FrmCapacidades frm;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (capacidad == null)
                {
                    capacidad = new Capacidad();
                }

                capacidad.capacidad = TextBoxCapacidad.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(capacidad);
                            if (frm != null)
                            {
                                frm.AgregarFila(capacidad);

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
            TextBoxCapacidad.Clear();
            TextBoxCapacidad.Focus();
            capacidad = null;
        }

        private bool ValidarObjeto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(capacidad))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCapacidad, "Capacidad Repetida");
            }

            return valido;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (capacidad != null)
            {
                TextBoxCapacidad.Text = capacidad.capacidad;
                _esEdicion = true;
            }
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxCapacidad.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxCapacidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCapacidad, "Debe ingresar una capacidad");
            }

            return valido;
        }

        private void TextBoxCapacidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
