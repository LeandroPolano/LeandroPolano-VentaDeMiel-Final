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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }


        private ServicioVenta _servicio;
        private List<Venta> _lista;


        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var venta in _lista)
            {
                AgregarFila(venta);
            }
        }

        public void AgregarFila(Venta venta)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, venta);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Venta venta)
        {
            r.Cells[CmnVenta.Index].Value = venta.VentaID;
            r.Cells[CmnFecha.Index].Value = venta.Fecha;
            r.Cells[CmnCliente.Index].Value = venta.Cliente.RazonSocial;
            r.Cells[CmnTotal.Index].Value = venta.Total;
            r.Tag = venta;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        //private void NuevoToolStripButton_Click(object sender, EventArgs e)
        //{
        //    FrmVentasAE frm = new FrmVentasAE(this) { Text = "Agregar Venta" };
        //    DialogResult dr = frm.ShowDialog(this);
        //}

        //private void BorrarToolStripButton_Click(object sender, EventArgs e)
        //{
        //    if (DatosDataGridView.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow r = DatosDataGridView.SelectedRows[0];
        //        Venta venta = (Venta)r.Tag;

        //        DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la Venta {venta.VentaID}?",
        //            "Confirmar Baja",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);
        //        if (dr == DialogResult.Yes)
        //        {
        //            if (!_servicio.EstaRelacionado(venta))
        //            {

        //                try
        //                {
        //                    _servicio.Borrar(venta.VentaID);
        //                    DatosDataGridView.Rows.Remove(r);
        //                    MessageBox.Show("Registro borrado");
        //                }
        //                catch (Exception exception)
        //                {
        //                    MessageBox.Show(exception.Message);

        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("Registro Relacionado");
        //            }
        //        }
        //    }
        //}

        //private void EditarToolStripButton_Click(object sender, EventArgs e)
        //{
        //    if (DatosDataGridView.SelectedRows.Count == 0)
        //    {
        //        return;
        //    }

        //    DataGridViewRow r = DatosDataGridView.SelectedRows[0];
        //    Venta p = (Venta)r.Tag;
        //    p = _servicio.GetVentaPorId(p.VentaID);
        //    FrmVentasAE frm = new FrmVentasAE();
        //    frm.Text = "Editar Venta";
        //   // frm.SetVenta(p);
        //    DialogResult dr = frm.ShowDialog(this);
        //    if (dr == DialogResult.OK)
        //    {
        //        try
        //        {
        //           // p = frm.GetVenta();
        //            _servicio.Guardar(p);
        //            SetearFila(r, p);
        //            MessageBox.Show("Registro modificado");
        //        }
        //        catch (Exception exception)
        //        {
        //            Console.WriteLine(exception);
        //            throw;
        //        }
        //    }
        //}

        ////private void CerrarToolStripButton_Click(object sender, EventArgs e)
        ////{
        ////    Close();
        ////}

        

        private void FrmVentas_Load_1(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioVenta();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void NuevoPanel_Paint(object sender, EventArgs e)
        {
            FrmVentasAE frm = new FrmVentasAE(this) { Text = "Agregar Venta" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
