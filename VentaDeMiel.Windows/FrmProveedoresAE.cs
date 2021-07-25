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
    public partial class FrmProveedoresAE : Form
    {

        public FrmProveedoresAE()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                }

                proveedor.Ciudad = (Ciudad)ComboBoxCiudad.SelectedItem;
                proveedor.RazonSocial = textBoxRazonSocial.Text;
                proveedor.Direccion = textBoxDireccion.Text;
                proveedor.Email = textBoxEmail.Text;
                proveedor.Cuit = decimal.Parse(textBoxCuit.Text);
                proveedor.CodigoPostal = decimal.Parse(textBoxCodigoPostal.Text);
                proveedor.Telefono = decimal.Parse(textBoxTelefono.Text);




                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicioProveedor.Guardar(proveedor);
                            if (frm != null)
                            {
                                frm.AgregarFila(proveedor);

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
        private FrmProveedores frm;
        public FrmProveedoresAE(FrmProveedores frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private readonly ServicioProveedor _servicioProveedor = new ServicioProveedor();
        private readonly ServicioCiudad _servicioCiudad = new ServicioCiudad();


        private Proveedor proveedor;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ServicioCiudad servicioCiudad = new ServicioCiudad();
            ComboBoxCiudad.DataSource = null;
            List<Ciudad> lista = servicioCiudad.GetLista();
            var defaultMedida = new Ciudad { CiudadID = 0, ciudad = "[Seleccione]" };
            lista.Insert(0, defaultMedida);
            ComboBoxCiudad.DataSource = lista;
            ComboBoxCiudad.DisplayMember = "ciudad";
            ComboBoxCiudad.ValueMember = "CiudadID";

            ComboBoxCiudad.SelectedIndex = 0;


            if (proveedor != null)
            {
                ComboBoxCiudad.SelectedValue = proveedor.Ciudad.CiudadID;
                textBoxRazonSocial.Text = proveedor.RazonSocial;
                textBoxCuit.Text = proveedor.Cuit.ToString();
                textBoxDireccion.Text = proveedor.Direccion.ToString();
                textBoxCodigoPostal.Text = proveedor.CodigoPostal.ToString();
                textBoxTelefono.Text = proveedor.Telefono.ToString();
                textBoxEmail.Text = proveedor.Email.ToString();
                _esEdicion = true;
            }
        }


        private bool _esEdicion = false;


        private bool ValidarDatos()
        {
            var valido = true;
            errorProvider1.Clear();
            if (ComboBoxCiudad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxCiudad, "Debe seleccionar una Ciudad");
            }

            if (string.IsNullOrEmpty(textBoxRazonSocial.Text) ||
                string.IsNullOrWhiteSpace(textBoxRazonSocial.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxRazonSocial, "Debe ingresar una Razon Social");
            }
            if (string.IsNullOrEmpty(textBoxCuit.Text) ||
                string.IsNullOrWhiteSpace(textBoxCuit.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCuit, "Debe ingresar un Cuit"); //
            }
            if (string.IsNullOrEmpty(textBoxDireccion.Text) ||
                string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxDireccion, "Debe ingresar una direccion");
            }
            
            if (string.IsNullOrEmpty(textBoxCodigoPostal.Text) ||
                string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCodigoPostal, "Debe ingresar un codigo postal"); //
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxEmail, "Debe ingresar un Email");
            }
            if (string.IsNullOrEmpty(textBoxTelefono.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTelefono, "Debe ingresar un Telefono");
            }
            decimal Cuit;
            decimal CodigoPostal;
            decimal Telefono;
            if (!decimal.TryParse(textBoxCuit.Text, out Cuit))
            {
                valido = false;
                errorProvider1.SetError(textBoxCuit, "Debe ingresar un Numero");
            }
            if (!decimal.TryParse(textBoxCodigoPostal.Text, out CodigoPostal))
            {
                valido = false;
                errorProvider1.SetError(textBoxCodigoPostal, "Debe ingresar un Numero");
            }
            if (!decimal.TryParse(textBoxTelefono.Text, out CodigoPostal))
            {
                valido = false;
                errorProvider1.SetError(textBoxTelefono, "Debe ingresar un Numero");
            }


            return valido;
        }

        private void InicializarControles()
        {

            proveedor = null;
            ComboBoxCiudad.SelectedIndex = 0;
            textBoxCuit.Clear();
            textBoxRazonSocial.Clear();
            textBoxDireccion.Clear();
            textBoxEmail.Clear();
            textBoxTelefono.Clear();
            textBoxCodigoPostal.Clear();

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicioProveedor.Existe(proveedor))
            {
                valido = false;
                errorProvider1.SetError(textBoxRazonSocial, "Proveedor repetido");
            }

            return valido;
        }



        public void SetProveedor(Proveedor Proveedor)
        {
            this.proveedor = Proveedor;
        }

        public Proveedor GetProveedor()
        {
            return proveedor;
        }

        private void FrmProveedoresAE_Load(object sender, EventArgs e)
        {

        }
    }
}
