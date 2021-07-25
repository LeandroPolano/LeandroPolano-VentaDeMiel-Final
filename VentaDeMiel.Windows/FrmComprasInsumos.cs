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
    public partial class FrmComprasInsumos : Form
    {
        public FrmComprasInsumos()
        {
            InitializeComponent();
        }

        private void CerrarPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void NuevoPanel_MouseClick(object sender, MouseEventArgs e)
        {
            FrmComprasInsumosAE frm = new FrmComprasInsumosAE(this);
            frm.ShowDialog(this);
        }

        private void CerrarPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
        private ServicioCompra _servicio;
        private List<Compra> _lista;    
        private void FrmComprasInsumos_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioCompra();
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
            foreach (var compra in _lista)
            {
                AgregarFila(compra);
            }
        }

        public void AgregarFila(Compra compra)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, compra);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Compra compra)
        {
            r.Cells[CmnFecha.Index].Value = compra.Fecha;
            r.Cells[CmnProveedor.Index].Value = compra.Proveedor.RazonSocial;
            r.Cells[CmnTotal.Index].Value = compra.Total;
            r.Tag = compra;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
