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
    public partial class FrmCiudadesAE : Form
    {
        public FrmCiudadesAE()
        {
            InitializeComponent();
        }

        

        private FrmCiudades frm;
        public FrmCiudadesAE(FrmCiudades frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private readonly ServicioCiudad _servicioProvincias = new ServicioCiudad();
        private readonly ServicioProvincia _servicioProvincia = new ServicioProvincia();

        private Ciudad ciudad;
        private ServicioCiudad _servicio = new ServicioCiudad();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ServicioProvincia servicioProvincia = new ServicioProvincia();
            ComboBoxProvincia.DataSource = null;
            List<Provincia> lista = servicioProvincia.GetLista();
            var defaultMedida = new Provincia { ProvinciaID = 0, provincia = "[Seleccione]" };
            lista.Insert(0, defaultMedida);
            ComboBoxProvincia.DataSource = lista;
            ComboBoxProvincia.DisplayMember = "provincia";
            ComboBoxProvincia.ValueMember = "ProvinciaID";
            ComboBoxProvincia.SelectedIndex = 0;
            if (ciudad != null)
            {
                ComboBoxProvincia.SelectedValue = ciudad.Provincia.ProvinciaID;
                textBoxCiudad.Text = ciudad.ciudad;

            }
        }







        private bool _esEdicion = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ciudad == null)
                {
                    ciudad = new Ciudad();
                }

                ciudad.Provincia = (Provincia)ComboBoxProvincia.SelectedItem;
                ciudad.ciudad = textBoxCiudad.Text;



                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(ciudad);
                            if (frm != null)
                            {
                                frm.AgregarFila(ciudad);

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

        private bool ValidarDatos()
        {
            var valido = true;
            errorProvider1.Clear();
            if (ComboBoxProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxProvincia, "Debe seleccionar una Provincia");
            }

            if (string.IsNullOrEmpty(textBoxCiudad.Text) ||
                string.IsNullOrWhiteSpace(textBoxCiudad.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCiudad, "Debe ingresar una ciudad");
            }


            return valido;
        }

        private void InicializarControles()
        {

            ciudad = null;
            ComboBoxProvincia.SelectedIndex = 0;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(ciudad))
            {
                valido = false;
                errorProvider1.SetError(textBoxCiudad, "Ciudad repetida");
            }

            return valido;
        }



        public void SetCiudad(Ciudad Ciudad)
        {
            this.ciudad = Ciudad;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

    }
}
