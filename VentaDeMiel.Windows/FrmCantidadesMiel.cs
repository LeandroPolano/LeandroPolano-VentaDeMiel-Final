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
    public partial class FrmCantidadesMiel : Form
    {
        public FrmCantidadesMiel()
        {
            InitializeComponent();
        }


        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmCantidadesMielAE frm = new FrmCantidadesMielAE(this);
            frm.Text = "Nueva CantidadMiel";
            DialogResult dr = frm.ShowDialog(this);
        }

        private void FrmCantidadesMiel_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioCantidadMiel();
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
            foreach (var cantidadMiel in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cantidadMiel);
                AgregarFila(r);
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
          
        }


        internal void AgregarFila(CantidadMiel cantidadMiel)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, cantidadMiel);
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

        private ServicioCantidadMiel _servicio;
        private List<CantidadMiel> _lista;

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                CantidadMiel cantidadMiel = (CantidadMiel)r.Tag;
                cantidadMiel = _servicio.GetCantidadMielPorId(cantidadMiel.CantidadMielID);
                FrmCantidadesMielAE frm = new FrmCantidadesMielAE();
                frm.Text = "Editar cantidadMiel";
                frm.SetCantidadMiel(cantidadMiel);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        var cantidad = frm.GetCantidadMiel();
                            _servicio.Guardar(cantidad);
                        cantidadMiel = _servicio.GetCantidadMielPorId(cantidadMiel.CantidadMielID);
                            SetearFila(r, cantidadMiel);
                            MessageBox.Show("Registro Editado");
            
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, CantidadMiel cantidadMiel)
        {
            r.Cells[CmlCantidadMiel.Index].Value = cantidadMiel.cantidadMiel;

            r.Tag = cantidadMiel;
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
