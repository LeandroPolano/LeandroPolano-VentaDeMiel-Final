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
    public partial class FrmTiposDeProductos : Form
    {
        public FrmTiposDeProductos()
        {
            InitializeComponent();
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmTiposDeProductosAE frm = new FrmTiposDeProductosAE(this);
            frm.Text = "Nueva TipoProducto";
            DialogResult dr = frm.ShowDialog(this);
        }



        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var tipoProducto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoProducto);
                AgregarFila(r);
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                TipoProducto tipoProducto = (TipoProducto)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la tipoProducto {tipoProducto.tipoProducto}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(tipoProducto))
                    {

                        try
                        {
                            _servicio.Borrar(tipoProducto.TipoProductoID);
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


        internal void AgregarFila(TipoProducto tipoProducto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, tipoProducto);
            AgregarFila(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private ServicioTipoProducto _servicio;
        private List<TipoProducto> _lista;

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                TipoProducto tipoProducto = (TipoProducto)r.Tag;
                tipoProducto = _servicio.GetTipoProductoPorId(tipoProducto.TipoProductoID);
                FrmTiposDeProductosAE frm = new FrmTiposDeProductosAE();
                frm.Text = "Editar tipoProducto";
                frm.SetTipoProducto(tipoProducto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipoProducto = frm.GetTipoProducto();
                        if (!_servicio.Existe(tipoProducto))
                        {
                            _servicio.Guardar(tipoProducto);
                            SetearFila(r, tipoProducto);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("tipoProducto Repetida");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, TipoProducto tipoProducto)
        {
            r.Cells[CmlTipoDeProducto.Index].Value = tipoProducto.tipoProducto;

            r.Tag = tipoProducto;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmTiposDeProductos_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioTipoProducto();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
