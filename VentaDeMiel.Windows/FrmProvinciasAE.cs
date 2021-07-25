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
    public partial class FrmProvinciasAE : Form
    {
        public FrmProvinciasAE()
        {
            InitializeComponent();
        }

        private FrmProvincias frm;
        public FrmProvinciasAE(FrmProvincias frm)
        {
            InitializeComponent();
            this.frm = frm;

        }
        

        private readonly ServicioProvincia _servicioPaises = new ServicioProvincia();
        private readonly ServicioPais _servicioPais = new ServicioPais();

        private Provincia provincia;
        private ServicioProvincia _servicio = new ServicioProvincia();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ServicioPais servicioPais = new ServicioPais();
            ComboBoxPais.DataSource = null;
            List<Pais> lista = servicioPais.GetLista();
            var defaultMedida = new Pais { PaisID = 0, pais = "[Seleccione]" };
            lista.Insert(0, defaultMedida);
            ComboBoxPais.DataSource = lista;
            ComboBoxPais.DisplayMember = "pais";
            ComboBoxPais.ValueMember = "PaisID";
            ComboBoxPais.SelectedIndex = 0;
            if (provincia != null)
            {
                ComboBoxPais.SelectedValue = provincia.Pais.PaisID;
                textBoxProvincia.Text = provincia.provincia;
                _esEdicion = true;

            }
        }

        

        

        

        private bool _esEdicion = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provincia == null)
                {
                    provincia = new Provincia();
                }

                provincia.Pais = (Pais)ComboBoxPais.SelectedItem;
                provincia.provincia = textBoxProvincia.Text;

                
                
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(provincia);
                            if (frm != null)
                            {
                                frm.AgregarFila(provincia);

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
            if (ComboBoxPais.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxPais, "Debe seleccionar una Pais");
            }

            if (string.IsNullOrEmpty(textBoxProvincia.Text) ||
                string.IsNullOrWhiteSpace(textBoxProvincia.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxProvincia, "Debe ingresar una provincia");
            }

            
            return valido;
        }

        private void InicializarControles()
        {

            provincia = null;
            ComboBoxPais.SelectedIndex = 0;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(provincia))
            {
                valido = false;
                errorProvider1.SetError(textBoxProvincia, "Provincia repetida");
            }

            return valido;
        }

       

        public void SetProvincia(Provincia Provincia)
        {
            this.provincia = Provincia;
        }

        public Provincia GetProvincia()
        {
            return provincia;
        }

        
    }
}
