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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }
        private ServicioProducto _servicio;
        private List<Producto> _lista;
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioProducto();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Producto producto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, producto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Producto producto)
        {
            r.Cells[CmlProducto.Index].Value = producto.producto;
            r.Cells[CmlMarca.Index].Value = producto.Marca.marca;
            r.Cells[CmlTipoProducto.Index].Value = producto.TipoProducto.tipoProducto;
            r.Cells[CmlStock.Index].Value = producto.Stock;
            r.Tag = producto;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmProductosAE frm = new FrmProductosAE(this) { Text = "Agregar Producto" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Producto  producto = (Producto)r.Tag;
                

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a el Producto {producto.producto}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(producto.ProductoID);
                        DatosDataGridView.Rows.Remove(r);
                        MessageBox.Show("Registro borrado");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                }
            }
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Producto p = (Producto)r.Tag;
            p = _servicio.GetProductoPorId(p.ProductoID);
            FrmProductosAE frm = new FrmProductosAE();
            frm.Text = "Editar Producto";
            frm.SetProducto(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetProducto();
                    _servicio.Guardar(p);
                    SetearFila(r, p);
                    MessageBox.Show("Registro modificado");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
