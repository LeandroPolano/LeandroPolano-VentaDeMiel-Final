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
    public partial class FrmComprasInsumosAE : Form
    {
        public FrmComprasInsumosAE()
        {
            InitializeComponent();
        }

        public FrmComprasInsumosAE(FrmComprasInsumos frmComprasInsumos)
        {
            this.frmCompras = frmComprasInsumos;
            InitializeComponent();
        }



        private void FrmComprasAE_Load(object sender, EventArgs e)
        {
            ServicioProveedor servicioProveedor = new ServicioProveedor();
            ComboBoxProveedor.DataSource = null;
            List<Proveedor> lista = servicioProveedor.GetLista();
            var defaultMedidaSC = new Proveedor { ProveedorID = 0, RazonSocial = "[Seleccione]" };
            lista.Insert(0, defaultMedidaSC);
            ComboBoxProveedor.DataSource = lista;
            ComboBoxProveedor.DisplayMember = "RazonSocial";
            ComboBoxProveedor.ValueMember = "ProveedorID";

            ComboBoxProveedor.SelectedIndex = 0;

            //ServicioProducto servicioProducto = new ServicioProducto();
            //ComboBoxProducto.DataSource = null;
            //List<Producto> listaP = servicioProducto.GetLista();
            //var defaultMedidaP = new Producto { ProductoID = 0, producto = "[Seleccione]" };
            //listaP.Insert(0, defaultMedidaP);
            //ComboBoxProducto.DataSource = listaP;
            //ComboBoxProducto.DisplayMember = "producto";
            //ComboBoxProducto.ValueMember = "ProductoID";

            //ComboBoxProducto.SelectedIndex = 0;

            ServicioInsumo servicioInsumo= new ServicioInsumo();
            comboBoxInsumo.DataSource = null;
            List<Insumo> listaTE = servicioInsumo.GetLista();
            var defaultMedidaTE = new Insumo { InsumoID = 0, insumo = "[Seleccione]" };
            listaTE.Insert(0, defaultMedidaTE);
            comboBoxInsumo.DataSource = listaTE;
            comboBoxInsumo.DisplayMember = "insumo";
            comboBoxInsumo.ValueMember = "InsumoID";

            comboBoxInsumo.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<CompraInsumo> lista = new List<CompraInsumo>();
        private Compra compra;
        private void Agregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var comprasInsumo = new CompraInsumo();
                comprasInsumo.Cantidad = decimal.Parse(TextBoxCantidad.Text);
                comprasInsumo.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                comprasInsumo.Insumo = (Insumo)comboBoxInsumo.SelectedItem;
                //if (VerificarRepetido(comprasProductos.Producto))
                //{
                //    lista.Add(comprasProductos);
                //    AgregarFila(comprasProductos); 

                //}
                foreach (var ci in lista)
                {
                    if (ci.Insumo == comprasInsumo.Insumo)
                    {
                        return;
                    }
                }
                    lista.Add(comprasInsumo);
                    AgregarFila(comprasInsumo);
                
              

                ActualizarTotal();

            }

        }

        //private bool VerificarRepetido(Producto producto)
        //{
        //    bool valido = true;
        //    foreach (var vp in lista)
        //    {
        //        if (vp.Producto==producto)
        //        {
        //            valido = false;
        //        }
        //    }
        //    return valido;
        //}

        decimal total;
        private void ActualizarTotal()
        {
            total = 0;
            foreach (var item in lista)
            {
                total += item.PrecioUnitario * item.Cantidad;
            }
            txtTotal.Text = total.ToString();
        }

        public void AgregarFila(CompraInsumo compraInsumo)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, compraInsumo);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, CompraInsumo compraInsumo)
        {
            //r.Cells[CmnProducto.Index].Value = compraProducto.Producto.producto;
            r.Cells[CmlCantidad.Index].Value = compraInsumo.Cantidad;
            r.Cells[CmlPrecioUnitario.Index].Value = compraInsumo.PrecioUnitario;
            r.Cells[CmlInsumo.Index].Value = compraInsumo.Insumo.insumo;
            r.Tag = compraInsumo;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }
        private bool ValidarDatos()
        {
            var valido = true;
            errorProvider1.Clear();
            //if (ComboBoxProducto.SelectedIndex == 0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(ComboBoxProducto, "Debe seleccionar un Producto");
            //}
            if (ComboBoxProveedor.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxProveedor, "Debe seleccionar un Proveedor");
            }
            if (comboBoxInsumo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxInsumo, "Debe seleccionar un Insumo");
            }
            if (string.IsNullOrEmpty(TextBoxCantidad.Text) ||
                string.IsNullOrWhiteSpace(TextBoxCantidad.Text))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidad, "Debe ingresar una Cantidad");
            }
            if (string.IsNullOrEmpty(txtPrecioUnitario.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioUnitario, "Debe ingresar un Precio");
            }
            decimal precio;
            if (!decimal.TryParse(txtPrecioUnitario.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioUnitario, "Debe ingresar un Numero");
            }
            if (precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioUnitario, "Debe ingresar un Precio valido");
            }
            decimal cantidad;
            if (!decimal.TryParse(TextBoxCantidad.Text, out cantidad))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidad, "Debe ingresar un Numero");
            }
            if (cantidad <= 0)
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidad, "Debe ingresar una Cantidad valida");
            }


            return valido;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (ValidarCompras())
            {

                try
                {
                    var compra = new Compra();
                    compra.Fecha = DateTime.Now;
                    compra.Proveedor = (Proveedor)ComboBoxProveedor.SelectedItem;
                    compra.Total = total;
                    compra.CompraInsumos = lista;
                    serviciocompra.Guardar(compra);
                    frmCompras.AgregarFila(compra);
                    Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        private ServicioCompra serviciocompra = new ServicioCompra();
        private FrmComprasInsumos frmCompras;

        private bool ValidarCompras()
        {
            var valido = true;
            errorProvider1.Clear();
            if (ComboBoxProveedor.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxProveedor, "Debe seleccionar un Proveedor");
            }
            if (ComboBoxProveedor.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxProveedor, "Debe seleccionar un Proveedor");
            }
            if (comboBoxInsumo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxInsumo, "Debe seleccionar un Insumo");
            }
            if (string.IsNullOrEmpty(TextBoxCantidad.Text) ||
                string.IsNullOrWhiteSpace(TextBoxCantidad.Text))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidad, "Debe ingresar una Cantidad");
            }
            if (string.IsNullOrEmpty(txtPrecioUnitario.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioUnitario, "Debe ingresar un Precio");
            }
            decimal precio;
            if (!decimal.TryParse(txtPrecioUnitario.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioUnitario, "Debe ingresar un Numero");
            }
            if (precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioUnitario, "Debe ingresar un Precio valido");
            }
            decimal cantidad;
            if (!decimal.TryParse(TextBoxCantidad.Text, out cantidad))
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidad, "Debe ingresar un Numero");
            }
            if (cantidad <= 0)
            {
                valido = false;
                errorProvider1.SetError(TextBoxCantidad, "Debe ingresar una Cantidad valida");
            }
            //if (lista.Count == 0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(btnVender, "Debe ingresar un producto a la lista de compra");
            //}
            return valido;
        }
    }
}
