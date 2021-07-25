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
    public partial class FrmMarcas : Form
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }
        
        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmMarcasAE frm = new FrmMarcasAE(this);
            frm.Text = "Nueva Marca";
            DialogResult dr = frm.ShowDialog(this);
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioMarca();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var marca in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, marca);
                AgregarFila(r);
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Marca marca = (Marca)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la marca {marca.marca}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(marca))
                    {

                    try
                    {
                        _servicio.Borrar(marca.MarcaID);
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

        
        internal void AgregarFila(Marca marca)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, marca);
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

        private ServicioMarca _servicio;
        private List<Marca> _lista;

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Marca marca = (Marca)r.Tag;
                marca = _servicio.GetMarcaPorId(marca.MarcaID);
                FrmMarcasAE frm = new FrmMarcasAE();
                frm.Text = "Editar marca";
                frm.SetMarca(marca);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        marca = frm.GetMarca();
                        if (!_servicio.Existe(marca))
                        {
                            _servicio.Guardar(marca);
                            SetearFila(r, marca);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Marca Repetida");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Marca marca)
        {
            r.Cells[CmlMarca.Index].Value = marca.marca;

            r.Tag = marca;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
