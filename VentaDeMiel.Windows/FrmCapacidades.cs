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
    public partial class FrmCapacidades : Form
    {
        public FrmCapacidades()
        {
            InitializeComponent();
        }

        

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmCapacidadesAE frm = new FrmCapacidadesAE(this);
            frm.Text = "Nueva Capacidad";
            DialogResult dr = frm.ShowDialog(this);
        }

        private void FrmCapacidades_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioCapacidad();
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
            foreach (var capacidad in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, capacidad);
                AgregarFila(r);
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Capacidad capacidad = (Capacidad)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la capacidad {capacidad.capacidad}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(capacidad.CapacidadID);
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


        internal void AgregarFila(Capacidad capacidad)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, capacidad);
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

        private ServicioCapacidad _servicio;
        private List<Capacidad> _lista;

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Capacidad capacidad = (Capacidad)r.Tag;
                capacidad = _servicio.GetCapacidadPorId(capacidad.CapacidadID);
                FrmCapacidadesAE frm = new FrmCapacidadesAE();
                frm.Text = "Editar capacidad";
                frm.SetCapacidad(capacidad);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        capacidad = frm.GetCapacidad();
                        if (!_servicio.Existe(capacidad))
                        {
                            _servicio.Guardar(capacidad);
                            SetearFila(r, capacidad);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("capacidad Repetida");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Capacidad capacidad)
        {
            r.Cells[CmlCapacidad.Index].Value = capacidad.capacidad;

            r.Tag = capacidad;
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
