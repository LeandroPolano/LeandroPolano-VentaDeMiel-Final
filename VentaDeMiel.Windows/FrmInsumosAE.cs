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
    public partial class FrmInsumosAE : Form
    {
        public FrmInsumosAE()
        {
            InitializeComponent();
        }



        private FrmInsumos frm;
        public FrmInsumosAE(FrmInsumos frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private readonly ServicioInsumo _servicioInsumo= new ServicioInsumo();
        //private readonly ServicioProveedor _servicioProveedor = new ServicioProveedor();

        private Insumo insumo;
    
        private ServicioInsumo _servicio = new ServicioInsumo();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //ServicioProveedor servicioProveedor = new ServicioProveedor();
            ////ComboBoxProveedor.DataSource = null;
            ////List<Proveedor> lista = servicioProveedor.GetLista();
            //var defaultMedida = new Proveedor { ProveedorID = 0, RazonSocial = "[Seleccione]" };
            //lista.Insert(0, defaultMedida);
            ////ComboBoxProveedor.DataSource = lista;
            ////ComboBoxProveedor.DisplayMember = "RazonSocial";
            ////ComboBoxProveedor.ValueMember = "ProveedorID";
            ////ComboBoxProveedor.SelectedIndex = 0;
            if (insumo != null)
            {
                _esEdicion = true;
                //ComboBoxProveedor.SelectedValue = insumo.Proveedor.ProveedorID;
                textBoxInsumo.Text = insumo.insumo;
                textBoxCantidad.Text =insumo.Cantidad.ToString();

            }
        }







        private bool _esEdicion = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (insumo == null)
                {
                    insumo = new Insumo();
                }

                //insumo.Proveedor = (Proveedor)ComboBoxProveedor.SelectedItem;
                insumo.insumo = textBoxInsumo.Text;
                insumo.Cantidad = decimal.Parse(textBoxCantidad.Text);



                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(insumo);
                            if (frm != null)
                            {
                                frm.AgregarFila(insumo);

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
            //if (ComboBoxProveedor.SelectedIndex == 0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(ComboBoxProveedor, "Debe seleccionar un Proveedor");
            //}

            if (string.IsNullOrEmpty(textBoxInsumo.Text) ||
                string.IsNullOrWhiteSpace(textBoxInsumo.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxInsumo, "Debe ingresar un insumo");
            }
            if (string.IsNullOrEmpty(textBoxCantidad.Text) ||
                string.IsNullOrWhiteSpace(textBoxCantidad.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar una cantidad");
            }
            decimal cantidad;
            if (!decimal.TryParse(textBoxCantidad.Text, out cantidad))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar un numero");
            }
            if (cantidad <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar una cantidad valida");
            }

            return valido;
        }

        private void InicializarControles()
        {

            insumo = null;
            //ComboBoxProveedor.SelectedIndex = 0;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(insumo))
            {
                valido = false;
                errorProvider1.SetError(textBoxInsumo, "Insumo repetido");
            }

            return valido;
        }



        public void SetInsumo(Insumo Insumo)
        {
            this.insumo = Insumo;
        }

        public Insumo GetInsumo()
        {
            return insumo;
        }

        private void FrmInsumosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
