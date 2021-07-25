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
    public partial class FrmInsumos : Form
    {
        public FrmInsumos()
        {
            InitializeComponent();
        }


        private ServicioInsumo _servicio;
        private List<Insumo> _lista;


        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Insumo producto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, producto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Insumo insumo)
        {
            r.Cells[CmnInsumo.Index].Value = insumo.insumo;
            //r.Cells[CmnProveedor.Index].Value = insumo.Proveedor.RazonSocial;
            r.Cells[CmnCantidad.Index].Value = insumo.Cantidad;
            r.Tag = insumo;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmInsumosAE frm = new FrmInsumosAE(this) { Text = "Agregar Insumo" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Insumo insumo = (Insumo)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el Insumo {insumo.insumo}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(insumo))
                    {

                        try
                        {
                            _servicio.Borrar(insumo.InsumoID);
                            DatosDataGridView.Rows.Remove(r);
                            MessageBox.Show("Registro borrado");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Registro Relacionado");
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
            Insumo p = (Insumo)r.Tag;
            p = _servicio.GetInsumoPorId(p.InsumoID);
            FrmInsumosAE frm = new FrmInsumosAE();
            frm.Text = "Editar Insumo";
            frm.SetInsumo(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetInsumo();
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

        private void FrmInsumos_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioInsumo();
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
