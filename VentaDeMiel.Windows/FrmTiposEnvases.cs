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
    public partial class FrmTiposEnvases : Form
    {
        public FrmTiposEnvases()
        {
            InitializeComponent();
        }
        private ServicioTipoEnvase _servicio;
        private List<TipoEnvase> _lista;
        

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var tipoEnvase in _lista)
            {
                AgregarFila(tipoEnvase);
            }
        }

        public void AgregarFila(TipoEnvase tipoEnvase)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, tipoEnvase);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoEnvase tipoEnvase)
        {
            r.Cells[CmlTipoEnvase.Index].Value = tipoEnvase.tipoEnvase;
            r.Cells[CmlCapacidad.Index].Value = tipoEnvase.Capacidad.capacidad;
            r.Tag = tipoEnvase;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmTiposEnvasesAE frm = new FrmTiposEnvasesAE(this) { Text = "Agregar TipoEnvase" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                TipoEnvase tipoEnvase = (TipoEnvase)r.Tag;


                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a el TipoEnvase {tipoEnvase.tipoEnvase}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(tipoEnvase.TipoEnvaseID);
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
            TipoEnvase p = (TipoEnvase)r.Tag;
            p = _servicio.GetTipoEnvasePorId(p.TipoEnvaseID);
            FrmTiposEnvasesAE frm = new FrmTiposEnvasesAE();
            frm.Text = "Editar TipoEnvase";
            frm.SetTipoEnvase(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetTipoEnvase();
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


        private void FrmTiposEnvases_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioTipoEnvase();
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
