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
    public partial class FrmTiposDeProductosAE : Form
    {
        public FrmTiposDeProductosAE()
        {
            InitializeComponent();
        }

        public FrmTiposDeProductosAE(FrmTiposDeProductos frmTiposDeProductos)
        {
            this.frm = frmTiposDeProductos;
            InitializeComponent();

        }

        internal void SetTipoProducto(TipoProducto tipoProducto)
        {
            this.tipoProducto = tipoProducto;
        }

        internal TipoProducto GetTipoProducto()
        {
            return tipoProducto;
        }

        private void FrmTiposDeProductosAE_Load(object sender, EventArgs e)
        {

        }
        private TipoProducto tipoProducto;
        private bool _esEdicion = false;
        private ServicioTipoProducto _servicio = new ServicioTipoProducto();
        private FrmTiposDeProductos frmTiposDeProductos;
        private readonly FrmTiposDeProductos frm;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoProducto == null)
                {
                    tipoProducto = new TipoProducto();
                }

                tipoProducto.tipoProducto = TextBoxTipoDeProducto.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(tipoProducto);
                            if (frm != null)
                            {
                                frm.AgregarFila(tipoProducto);

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
            TextBoxTipoDeProducto.Clear();
            TextBoxTipoDeProducto.Focus();
            tipoProducto = null;
        }

        private bool ValidarObjeto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(tipoProducto))
            {
                valido = false;
                errorProvider1.SetError(TextBoxTipoDeProducto, "Tipo de Producto repetida");
            }

            return valido;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoProducto != null)
            {
                TextBoxTipoDeProducto.Text = tipoProducto.tipoProducto;
                _esEdicion = true;
            }
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(TextBoxTipoDeProducto.Text.Trim()) &&
                string.IsNullOrWhiteSpace(TextBoxTipoDeProducto.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TextBoxTipoDeProducto, "Debe ingresar una tipo de Producto");
            }

            return valido;
        }

        private void TextBoxTipoProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
