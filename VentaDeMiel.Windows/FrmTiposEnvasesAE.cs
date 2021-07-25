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
    public partial class FrmTiposEnvasesAE : Form
    {
        public FrmTiposEnvasesAE()
        {
            InitializeComponent();
        }

        private FrmTiposEnvases frm;
        public FrmTiposEnvasesAE(FrmTiposEnvases frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private ServicioTipoEnvase _servicioTipoEnvase = new ServicioTipoEnvase();
        private ServicioCapacidad servicioCapacidad = new ServicioCapacidad();
        private TipoEnvase tipoEnvase;
        private ServicioTipoEnvase _servicio = new ServicioTipoEnvase();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            

            base.OnLoad(e);
            ServicioCapacidad servicioCapacidad = new ServicioCapacidad();
            ComboBoxCapacidad.DataSource = null;
            List<Capacidad> listaC = servicioCapacidad.GetLista();
            var defaultCapacidad = new Capacidad { CapacidadID = 0, capacidad = "[Seleccione]" };
            listaC.Insert(0, defaultCapacidad);
            ComboBoxCapacidad.DataSource = listaC;
            ComboBoxCapacidad.DisplayMember = "capacidad";
            ComboBoxCapacidad.ValueMember = "CapacidadID";
            ComboBoxCapacidad.SelectedIndex = 0;
            if (tipoEnvase != null)
            {
                ComboBoxCapacidad.SelectedValue = tipoEnvase.Capacidad.CapacidadID;
                textBoxTipoEnvase.Text = tipoEnvase.tipoEnvase;
                _esEdicion = true;
            }
        }







        private bool _esEdicion = false;
        

        private bool ValidarDatos()
        {
            var valido = true;
            errorProvider1.Clear();
            if (ComboBoxCapacidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxCapacidad, "Debe seleccionar una Capacidad");
            }

            if (string.IsNullOrEmpty(textBoxTipoEnvase.Text) ||
                string.IsNullOrWhiteSpace(textBoxTipoEnvase.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTipoEnvase, "Debe ingresar un tipo de Envase");
            }


            return valido;
        }

        private void InicializarControles()
        {

            tipoEnvase = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(tipoEnvase))
            {
                valido = false;
                errorProvider1.SetError(textBoxTipoEnvase, "TipoEnvase repetida");
            }

            return valido;
        }



        public void SetTipoEnvase(TipoEnvase TipoEnvase)
        {
            this.tipoEnvase = TipoEnvase;
        }

        public TipoEnvase GetTipoEnvase()
        {
            return tipoEnvase;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoEnvase == null)
                {
                    tipoEnvase = new TipoEnvase();
                }

                tipoEnvase.Capacidad = (Capacidad)ComboBoxCapacidad.SelectedItem;
                tipoEnvase.tipoEnvase = textBoxTipoEnvase.Text;



                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(tipoEnvase);
                            if (frm != null)
                            {
                                frm.AgregarFila(tipoEnvase);

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
    }
}
