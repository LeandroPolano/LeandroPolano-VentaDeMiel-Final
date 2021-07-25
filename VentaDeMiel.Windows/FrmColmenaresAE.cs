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
    public partial class FrmColmenaresAE : Form
    {
        public FrmColmenaresAE()
        {
            InitializeComponent();
        }

            private FrmColmenares frm;
        public FrmColmenaresAE(FrmColmenares frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private readonly ServicioColmenar _servicioCiudades = new ServicioColmenar();
        private readonly ServicioCiudad _servicioCiudad = new ServicioCiudad();
        private readonly ServicioInsumo _servicioInsumo = new ServicioInsumo();
        private readonly ServicioEstadoColmena _servicioEstadoColmena = new ServicioEstadoColmena();
        private Colmenar colmenar;
        private ServicioColmenar _servicio = new ServicioColmenar();
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

            ServicioEstadoColmena servicioEstadoColmena = new ServicioEstadoColmena();
            ComboBoxEstadoColmena.DataSource = null;
            List<EstadoColmena> listaTP = servicioEstadoColmena.GetLista();
            var estadoColmena = new EstadoColmena { EstadoColmenaID = 0, estadoColmena = "[Seleccione]" };
            listaTP.Insert(0, estadoColmena);
            ComboBoxEstadoColmena.DataSource = listaTP;
            ComboBoxEstadoColmena.DisplayMember = "estadoColmena";
            ComboBoxEstadoColmena.ValueMember = "EstadoColmenaID";

            ComboBoxEstadoColmena.SelectedIndex = 0;


            ServicioInsumo servicioInsumo = new ServicioInsumo();
            ComboBoxInsumo.DataSource = null;
            List<Insumo> listaIN = servicioInsumo.GetLista();
            var insumo = new Insumo { InsumoID = 0, insumo = "[Seleccione]" };
            listaIN.Insert(0, insumo);
            ComboBoxInsumo.DataSource = listaIN;
            ComboBoxInsumo.DisplayMember = "insumo";
            ComboBoxInsumo.ValueMember = "InsumoID";

            ComboBoxEstadoColmena.SelectedIndex = 0;

            if (colmenar != null)
            {
                ComboBoxCiudad.SelectedValue = colmenar.Ciudad.CiudadID;
                ComboBoxInsumo.SelectedValue = colmenar.Insumo.InsumoID;
                ComboBoxEstadoColmena.SelectedValue = colmenar.EstadoColmena.EstadoColmenaID;
                textBoxColmenar.Text = colmenar.NombreColmenar;
                textBoxCantidadColmena.Text = colmenar.CantidadColmena.ToString();
                textBoxCantidadInsumo.Text = colmenar.CantidadInsumo.ToString();
                _esEdicion = true;
            }
        }

        private bool _esEdicion = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (colmenar == null)
                {
                    colmenar = new Colmenar();
                }

                colmenar.Ciudad = (Ciudad)ComboBoxCiudad.SelectedItem;
                colmenar.Insumo = (Insumo)ComboBoxInsumo.SelectedItem;
                colmenar.EstadoColmena = (EstadoColmena)ComboBoxEstadoColmena.SelectedItem;
                colmenar.NombreColmenar = textBoxColmenar.Text;
                colmenar.CantidadColmena =decimal.Parse( textBoxCantidadColmena.Text);
                colmenar.CantidadInsumo = decimal.Parse(textBoxCantidadInsumo.Text);
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(colmenar);
                            if (frm != null)
                            {
                                frm.AgregarFila(colmenar);

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
            if (ComboBoxCiudad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxCiudad, "Debe seleccionar una Ciudad");
            }
            if (ComboBoxInsumo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxInsumo, "Debe seleccionar un Insumo");
            }
            if (ComboBoxEstadoColmena.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxEstadoColmena, "Debe seleccionar un estado de las colmenas");
            }

            if (string.IsNullOrEmpty(textBoxColmenar.Text) ||
                string.IsNullOrWhiteSpace(textBoxColmenar.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxColmenar, "Debe ingresar una colmenar");
            }


            if (string.IsNullOrEmpty(textBoxCantidadColmena.Text) ||
                string.IsNullOrWhiteSpace(textBoxCantidadColmena.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxColmenar, "Debe ingresar una Cantidad de colmenas");
            }
            decimal cantidad = 0;
            if (!decimal.TryParse(textBoxCantidadColmena.Text,out cantidad))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidadColmena, "Debe ingresar una Cantidad de colmenas valida");

            }
            decimal cantidadInsumo = 0;
            if (!decimal.TryParse(textBoxCantidadInsumo.Text, out cantidadInsumo))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidadInsumo, "Debe ingresar una Cantidad de Insumo Valido");

            }

            if (string.IsNullOrEmpty(textBoxCantidadInsumo.Text) ||
                string.IsNullOrWhiteSpace(textBoxCantidadInsumo.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidadInsumo, "Debe ingresar una Cantidad De Insumo");
            }
            if (cantidadInsumo < 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidadInsumo, "Debe ingresar una Cantidad de Insumo Valido");

            }
            Insumo insumo =(Insumo) ComboBoxInsumo.SelectedItem;
            if (cantidadInsumo >insumo.Cantidad)
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidadInsumo, "Debe ingresar una Cantidad de Insumo Valido");
            }

            return valido;
        }

        private void InicializarControles()
        {

            colmenar = null;
            ComboBoxCiudad.SelectedIndex = 0;
            ComboBoxInsumo.SelectedIndex = 0;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(colmenar))
            {
                valido = false;
                errorProvider1.SetError(textBoxColmenar, "Colmenar repetido");
            }

            return valido;
        }

       public void SetColmenar(Colmenar Colmenar)
        {
            this.colmenar = Colmenar;
        }

        public Colmenar GetColmenar()
        {
            return colmenar;
        }

        private void FrmColmenaresAE_Load(object sender, EventArgs e)
        {

        }
    }
    
}
