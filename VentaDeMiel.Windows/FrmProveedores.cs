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
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }
        private ServicioProveedor _servicio;
        private List<Proveedor> _lista;
        

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Proveedor proveedor)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, proveedor);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Proveedor proveedor)
        {
            r.Cells[CmlCuit.Index].Value = proveedor.Cuit;
            r.Cells[CmlRazonSocial.Index].Value = proveedor.RazonSocial;
            r.Cells[CmlDireccion.Index].Value = proveedor.Direccion;
            r.Cells[CmlCiudad.Index].Value = proveedor.Ciudad.ciudad;
            r.Cells[CmlCodigoPostal.Index].Value = proveedor.CodigoPostal;
            r.Cells[CmlTelefono.Index].Value = proveedor.Telefono;
            r.Cells[CmlEmail.Index].Value = proveedor.Email;
            r.Tag = proveedor;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmProveedoresAE frm = new FrmProveedoresAE(this) { Text = "Agregar Proveedor" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Proveedor proveedor = (Proveedor)r.Tag;


                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a el Producto {proveedor.RazonSocial}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(proveedor.ProveedorID);
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
            Proveedor p = (Proveedor)r.Tag;
            p = _servicio.GetProveedorPorId(p.ProveedorID);
            FrmProveedoresAE frm = new FrmProveedoresAE();
            frm.Text = "Editar Proveedor";
            frm.SetProveedor(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetProveedor();
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

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioProveedor();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
