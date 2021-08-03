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
    public partial class FrmVentasAE : Form
    {
        public FrmVentasAE()
        {
            InitializeComponent();
        }

        public FrmVentasAE(FrmVentas frmVentas)
        {
            this.frmVentas = frmVentas;
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmVentasAE_Load(object sender, EventArgs e)
        {
            ServicioClienteDeMiel servicioCliente = new ServicioClienteDeMiel();
            ComboBoxCliente.DataSource = null;
            List<ClienteDeMiel> lista = servicioCliente.GetLista();
            var defaultMedidaSC = new ClienteDeMiel { ClienteID = 0, RazonSocial = "[Seleccione]" };
            lista.Insert(0, defaultMedidaSC);
            ComboBoxCliente.DataSource = lista;
            ComboBoxCliente.DisplayMember = "RazonSocial";
            ComboBoxCliente.ValueMember = "ClienteID";

            ComboBoxCliente.SelectedIndex = 0;

            //ServicioProducto servicioProducto = new ServicioProducto();
            //ComboBoxProducto.DataSource = null;
            //List<Producto> listaP = servicioProducto.GetLista();
            //var defaultMedidaP = new Producto { ProductoID = 0, producto = "[Seleccione]" };
            //listaP.Insert(0, defaultMedidaP);
            //ComboBoxProducto.DataSource = listaP;
            //ComboBoxProducto.DisplayMember = "producto";
            //ComboBoxProducto.ValueMember = "ProductoID";

            //ComboBoxProducto.SelectedIndex = 0;

            ServicioTipoEnvase servicioTipoEnvase = new ServicioTipoEnvase();
            ComboBoxTipoEnvase.DataSource = null;
            List<TipoEnvase> listaTE = servicioTipoEnvase.GetLista();
            var defaultMedidaTE = new TipoEnvase { TipoEnvaseID = 0, tipoEnvase = "[Seleccione]" };
            listaTE.Insert(0, defaultMedidaTE);
            ComboBoxTipoEnvase.DataSource = listaTE;
            ComboBoxTipoEnvase.DisplayMember = "tipoEnvase";
            ComboBoxTipoEnvase.ValueMember = "TipoEnvaseID";

            ComboBoxTipoEnvase.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<VentaProducto> lista = new List<VentaProducto>();
        private Venta venta;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var ventasProductos = new VentaProducto();
                ventasProductos.Cantidad =decimal.Parse(textBoxCantidad.Text);
                ventasProductos.Precio =decimal.Parse( textBoxPrecio.Text);
                //ventasProductos.Producto =(Producto) ComboBoxProducto.SelectedItem;
                ventasProductos.TipoEnvase = (TipoEnvase)ComboBoxTipoEnvase.SelectedItem;
                //if (VerificarRepetido(ventasProductos.Producto))
                //{
                //    lista.Add(ventasProductos);
                //    AgregarFila(ventasProductos); 

                //}
                lista.Add(ventasProductos);
                AgregarFila(ventasProductos);

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
                total += item.Precio * item.Cantidad;
            }
            textBoxTotal.Text = total.ToString();
        }

        public void AgregarFila(VentaProducto ventaProducto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, ventaProducto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, VentaProducto ventaProducto)
        {
            //r.Cells[CmnProducto.Index].Value = ventaProducto.Producto.producto;
            r.Cells[CmnCantidad.Index].Value = ventaProducto.Cantidad;
            r.Cells[CmnTipoEnvase.Index].Value = ventaProducto.TipoEnvase.tipoEnvase;
            r.Cells[CmnPrecioUnitario.Index].Value = ventaProducto.Precio;
            r.Cells[cmnPesoTotal.Index].Value = decimal.Parse(ventaProducto.TipoEnvase.Capacidad.capacidad)* ventaProducto.Cantidad;
            r.Tag = ventaProducto;
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
            if (ComboBoxTipoEnvase.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxTipoEnvase, "Debe seleccionar un Tipo De Envase");
            }

            if (string.IsNullOrEmpty(textBoxCantidad.Text) ||
                string.IsNullOrWhiteSpace(textBoxCantidad.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar una Cantidad");
            }
            if (string.IsNullOrEmpty(textBoxPrecio.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrecio.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxPrecio, "Debe ingresar un Precio");
            }
            decimal precio;
            if (!decimal.TryParse(textBoxPrecio.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(textBoxPrecio, "Debe ingresar un Numero");
            }
            if (precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxPrecio, "Debe ingresar un Precio valido");
            }
            decimal cantidad;
            if (!decimal.TryParse(textBoxCantidad.Text, out cantidad))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar un Numero");
            }
            if (cantidad <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar una Cantidad valida");
            }


            return valido;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (ValidarVentas())
            {

                try
                {
                    var venta = new Venta();
                    venta.Fecha = DateTime.Now;
                    venta.Cliente = (ClienteDeMiel)ComboBoxCliente.SelectedItem;
                    venta.Total = total;
                    venta.VentaProductos = lista;
                    if (validarCantidad(venta))
                    {
                        
                        servicioVenta.Guardar(venta); 
                    frmVentas.AgregarFila(venta);
                    Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private bool validarCantidad(Venta venta)
        {
            var valido = true;
            errorProvider1.Clear();
            decimal Cant = 0;
            foreach (var vp in venta.VentaProductos)
            {
                var capacidad = decimal.Parse(vp.TipoEnvase.Capacidad.capacidad);
                var MielCantidad = vp.Cantidad * capacidad;
                Cant += MielCantidad;
            }
            CantidadMiel cantidadMiel = servicioCantidadMiel.GetCantidadMielPorId(1);
            if (cantidadMiel.cantidadMiel < Cant)
            {
                valido = false;
                errorProvider1.SetError(btnVender, "Debe ingresar una Cantidad que no sobrepase el stock");
            }
            return valido;
        }

        private ServicioVenta servicioVenta = new ServicioVenta();
        private FrmVentas frmVentas;

        private bool ValidarVentas()
        {
            var valido = true;
            errorProvider1.Clear();
            if (ComboBoxCliente.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxCliente, "Debe seleccionar un Cliente");
            }
            if (ComboBoxTipoEnvase.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ComboBoxTipoEnvase, "Debe seleccionar un Tipo De Envase");
            }

            if (string.IsNullOrEmpty(textBoxCantidad.Text) ||
                string.IsNullOrWhiteSpace(textBoxCantidad.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar una Cantidad");
            }
            if (string.IsNullOrEmpty(textBoxPrecio.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrecio.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxPrecio, "Debe ingresar un Precio");
            }
            decimal precio;
            if (!decimal.TryParse(textBoxPrecio.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(textBoxPrecio, "Debe ingresar un Numero");
            }
            if (precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxPrecio, "Debe ingresar un Precio valido");
            }
            decimal cantidad;
            if (!decimal.TryParse(textBoxCantidad.Text, out cantidad))
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar un Numero");
            }
            if (cantidad <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxCantidad, "Debe ingresar una Cantidad valida");
            }
            if (lista.Count <= 0)
            {
                valido = false;
                errorProvider1.SetError(btnVender, "Debe ingresar un producto a la lista de venta");
            }
            return valido;
        }
        ServicioCantidadMiel servicioCantidadMiel= new ServicioCantidadMiel();

        private void DatosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow r = DatosDataGridView.Rows[e.RowIndex];
                VentaProducto ventaProducto = (VentaProducto)r.Tag;
                DatosDataGridView.Rows.RemoveAt(e.RowIndex);
                lista.Remove(ventaProducto);
                ActualizarTotal();

            }
        }
    }
}
