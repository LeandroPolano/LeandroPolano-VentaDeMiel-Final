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
    public partial class FrmClientesDeMielAE : Form
    {
        public FrmClientesDeMielAE()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clienteDeMiel == null)
                {
                    clienteDeMiel = new ClienteDeMiel();
                }

                clienteDeMiel.Ciudad = (Ciudad)ComboBoxCiudad.SelectedItem;
                clienteDeMiel.TipoDocumento = (TipoDocumento)ComboBoxTipoDocumento.SelectedItem;
                clienteDeMiel.RazonSocial = textBoxRazonSocial.Text;
                clienteDeMiel.Direccion = textBoxDireccion.Text;
                clienteDeMiel.Email = textBoxEmail.Text;
                clienteDeMiel.CodigoPostal = decimal.Parse(textBoxCodigoPostal.Text);
                clienteDeMiel.Telefono = decimal.Parse(textBoxTelefono.Text);
                clienteDeMiel.NumeroDocumento = decimal.Parse(textBoxNumeroDocumento.Text);


                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicioClienteDeMiel.Guardar(clienteDeMiel);
                            if (frm != null)
                            {
                                frm.AgregarFila(clienteDeMiel);

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
        private FrmClientesDeMiel frm;
        public FrmClientesDeMielAE(FrmClientesDeMiel frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private readonly ServicioClienteDeMiel _servicioClienteDeMiel = new ServicioClienteDeMiel();
        private readonly ServicioCiudad _servicioCiudad = new ServicioCiudad();
        private readonly ServicioTipoDocumento _servicioTipoDocumento = new ServicioTipoDocumento();



        private ClienteDeMiel clienteDeMiel;
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

            base.OnLoad(e);
            ServicioTipoDocumento servicioTipoDocumento = new ServicioTipoDocumento();
            ComboBoxTipoDocumento.DataSource = null;
            List<TipoDocumento> listaTD = servicioTipoDocumento.GetLista();
            var defaultTD = new TipoDocumento { TipoDocumentoID = 0, tipoDocumento = "[Seleccione]" };
            listaTD.Insert(0, defaultTD);
            ComboBoxTipoDocumento.DataSource = listaTD;
            ComboBoxTipoDocumento.DisplayMember = "tipoDocumento";
            ComboBoxTipoDocumento.ValueMember = "TipoDocumentoID";

            ComboBoxCiudad.SelectedIndex = 0;

            if (clienteDeMiel != null)
            {
                ComboBoxCiudad.SelectedValue = clienteDeMiel.Ciudad.CiudadID;
                textBoxRazonSocial.Text = clienteDeMiel.RazonSocial;
                textBoxDireccion.Text = clienteDeMiel.Direccion.ToString();
                textBoxCodigoPostal.Text = clienteDeMiel.CodigoPostal.ToString();
                textBoxTelefono.Text = clienteDeMiel.Telefono.ToString();
                textBoxEmail.Text = clienteDeMiel.Email.ToString();
                ComboBoxTipoDocumento.SelectedValue = clienteDeMiel.TipoDocumento.TipoDocumentoID;
                textBoxNumeroDocumento.Text = clienteDeMiel.NumeroDocumento.ToString();
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
            errorProvider1.Clear();
            if (ComboBoxTipoDocumento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxTipoDocumento, "Debe seleccionar un Tipo de Documento");
            }

            if (string.IsNullOrEmpty(textBoxRazonSocial.Text) ||
                string.IsNullOrWhiteSpace(textBoxRazonSocial.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxRazonSocial, "Debe ingresar una Razon Social");
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
                errorProvider1.SetError(textBoxCodigoPostal, "Debe ingresar un codigo postal");
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
            decimal CodigoPostal;
            decimal Telefono;
            decimal numerodocumento;
            
            if (!decimal.TryParse(textBoxCodigoPostal.Text, out CodigoPostal))
            {
                valido = false;
                errorProvider1.SetError(textBoxCodigoPostal, "Debe ingresar un Numero");
            }
            if (!decimal.TryParse(textBoxTelefono.Text, out Telefono))
            {
                valido = false;
                errorProvider1.SetError(textBoxTelefono, "Debe ingresar un Numero");
            }
            if (!decimal.TryParse(textBoxNumeroDocumento.Text, out numerodocumento))
            {
                valido = false;
                errorProvider1.SetError(textBoxNumeroDocumento, "Debe ingresar un Numero");
            }

            return valido;
        }

        private void InicializarControles()
        {

            clienteDeMiel = null;
            ComboBoxCiudad.SelectedIndex = 0;
            ComboBoxTipoDocumento.SelectedIndex = 0;
            textBoxRazonSocial.Clear();
            textBoxDireccion.Clear();
            textBoxEmail.Clear();
            textBoxTelefono.Clear();
            textBoxCodigoPostal.Clear();
            textBoxNumeroDocumento.Clear();
            

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicioClienteDeMiel.Existe(clienteDeMiel))
            {
                valido = false;
                errorProvider1.SetError(textBoxRazonSocial, "Cliente De Miel repetido");
            }

            return valido;
        }



        public void SetClienteDeMiel(ClienteDeMiel ClienteDeMiel)
        {
            this.clienteDeMiel = ClienteDeMiel;
        }

        public ClienteDeMiel GetClienteDeMiel()
        {
            return clienteDeMiel;
        }

        private void FrmClientesDeMielAE_Load(object sender, EventArgs e)
        {

        }
    }
}
