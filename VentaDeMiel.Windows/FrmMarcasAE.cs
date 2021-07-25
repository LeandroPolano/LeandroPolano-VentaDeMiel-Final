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
    public partial class FrmMarcasAE : Form
    {
        public FrmMarcasAE()
        {
            InitializeComponent();
        }

        public FrmMarcasAE(FrmMarcas frmMarcas)
        {
            this.frm = frmMarcas;
            InitializeComponent();

        }

        internal void SetMarca(Marca marca)
        {
            this.marca = marca;
        }

        internal Marca GetMarca()
        {
            return marca;
        }

        private void FrmMarcasAE_Load(object sender, EventArgs e)
        {

        }
        private Marca marca;
        private bool _esEdicion = false;
        private ServicioMarca _servicio = new ServicioMarca();
        private FrmMarcas frmMarcas;     
        private readonly FrmMarcas frm;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.marca = TextBoxMarca.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(marca);
                            if (frm != null)
                            {
                                frm.AgregarFila(marca);

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
            TextBoxMarca.Clear();
            TextBoxMarca.Focus();
            marca = null;
        }

        private bool ValidarObjeto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(marca))
            {
                valido = false;
                errorProvider1.SetError(TextBoxMarca, "Marca repetida");
                marca = null;
            }

            return valido;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (marca != null)
            {
                TextBoxMarca.Text = marca.marca;
                _esEdicion = true;
            }
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxMarca.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxMarca.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxMarca, "Debe ingresar una marca");
            }

            return valido;
        }

        private void TextBoxMarca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
