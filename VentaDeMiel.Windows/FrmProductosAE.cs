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
    public partial class FrmProductosAE : Form
    {
        public FrmProductosAE()
        {
            InitializeComponent();
        }

        private FrmProductos frm;
        public FrmProductosAE(FrmProductos frm)
        {
            InitializeComponent();
            this.frm = frm;

        }


        private readonly ServicioProducto _servicioProducto = new ServicioProducto();
        private readonly ServicioMarca _servicioMarca = new ServicioMarca();
        private readonly ServicioTipoProducto _servicioTipoProducto = new ServicioTipoProducto();


        private Producto producto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ServicioMarca servicioMarca = new ServicioMarca();
            ComboBoxMarca.DataSource = null;
            List<Marca> lista = servicioMarca.GetLista();
            var defaultMedida = new Marca { MarcaID = 0, marca = "[Seleccione]" };
            lista.Insert(0, defaultMedida);
            ComboBoxMarca.DataSource = lista;
            ComboBoxMarca.DisplayMember = "marca";
            ComboBoxMarca.ValueMember = "MarcaID";

            ComboBoxMarca.SelectedIndex = 0;

            ServicioTipoProducto servicioTipoProducto = new ServicioTipoProducto();
            ComboBoxTipoProducto.DataSource = null;
            List<TipoProducto> listaTP = servicioTipoProducto.GetLista();
            var defaultTipoProducto = new TipoProducto { TipoProductoID = 0, tipoProducto = "[Seleccione]" };
            listaTP.Insert(0, defaultTipoProducto);
            ComboBoxTipoProducto.DataSource = listaTP;
            ComboBoxTipoProducto.DisplayMember = "tipoProducto";
            ComboBoxTipoProducto.ValueMember = "TipoProductoID";

            ComboBoxTipoProducto.SelectedIndex = 0;
            if (producto != null)
            {
                ComboBoxTipoProducto.SelectedValue = producto.TipoProducto.TipoProductoID;
                ComboBoxMarca.SelectedValue = producto.Marca.MarcaID;
                textBoxProducto.Text = producto.producto;
                textBoxStock.Text = producto.Stock.ToString();
                _esEdicion = true;
            }
        }


        private bool _esEdicion = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();
                }

                producto.Marca = (Marca)ComboBoxMarca.SelectedItem;
                producto.TipoProducto = ComboBoxTipoProducto.SelectedItem as TipoProducto;
                producto.producto = textBoxProducto.Text;
                producto.Stock = decimal.Parse(textBoxStock.Text);




                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicioProducto.Guardar(producto);
                            if (frm != null)
                            {
                                frm.AgregarFila(producto);

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
            if (ComboBoxMarca.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxMarca, "Debe seleccionar una Marca");
            }
            if (ComboBoxTipoProducto.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxTipoProducto, "Debe seleccionar un Tipo de Producto");
            }
            if (string.IsNullOrEmpty(textBoxProducto.Text) ||
                string.IsNullOrWhiteSpace(textBoxProducto.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxProducto, "Debe ingresar una producto");
            }
            if (string.IsNullOrEmpty(textBoxStock.Text) ||
                string.IsNullOrWhiteSpace(textBoxStock.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxStock, "Debe ingresar un stock");
            }
            decimal stock;
            if (!decimal.TryParse(textBoxStock.Text, out stock))
            {
                valido = false;
                errorProvider1.SetError(textBoxStock, "Debe ingresar un Numero");
            }
            if (stock<=0)
            {
                valido = false;
                errorProvider1.SetError(textBoxStock, "Debe ingresar un stock valido");
            }


            return valido;
        }

        private void InicializarControles()
        {

            producto = null;
            ComboBoxMarca.SelectedIndex = 0;
            ComboBoxTipoProducto.SelectedIndex = 0;
            textBoxStock.Clear();
            textBoxProducto.Clear();

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicioProducto.Existe(producto))
            {
                valido = false;
                errorProvider1.SetError(textBoxProducto, "Producto repetido");
            }

            return valido;
        }



        public void SetProducto(Producto Producto)
        {
            this.producto = Producto;
        }

        public Producto GetProducto()
        {
            return producto;
        }

        private void FrmProductosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
