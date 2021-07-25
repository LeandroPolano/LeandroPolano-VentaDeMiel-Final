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
    public partial class FrmColmenas : Form
    {
        public FrmColmenas()
        {
            InitializeComponent();
        }

      

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmColmenasAE frm = new FrmColmenasAE(this);
            frm.Text = "Nueva Colmena";
            DialogResult dr = frm.ShowDialog(this);
        }

      

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var CantidadDeAlzas in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, CantidadDeAlzas);
                AgregarFila(r);
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Colmena CantidadDeAlzas = (Colmena)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la Cantidad De Alzas {CantidadDeAlzas.ClaveColmena}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(CantidadDeAlzas))
                    {

                    try
                    {
                        _servicio.Borrar(CantidadDeAlzas.ColmenaID);
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


        internal void AgregarFila(Colmena CantidadDeAlzas)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, CantidadDeAlzas);
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

        private ServicioColmena _servicio;
        private List<Colmena> _lista;

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Colmena CantidadDeAlzas = (Colmena)r.Tag;
                CantidadDeAlzas = _servicio.GetColmenaPorId(CantidadDeAlzas.ColmenaID);

                FrmColmenasAE frm = new FrmColmenasAE();
                frm.Text = "Editar Cantidad De Alzas";
                frm.SetColmena(CantidadDeAlzas);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        CantidadDeAlzas = frm.GetColmena();
                        if (!_servicio.Existe(CantidadDeAlzas))
                        {
                            _servicio.Guardar(CantidadDeAlzas);
                            SetearFila(r, CantidadDeAlzas);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Cantidad De Alzas Repetida");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Colmena CantidadDeAlzas)
        {
            r.Cells[CmlClaveColmena.Index].Value = CantidadDeAlzas.ClaveColmena;

            r.Tag = CantidadDeAlzas;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmColmenas_Load_1(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioColmena();
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
