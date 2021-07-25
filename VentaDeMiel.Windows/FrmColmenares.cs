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
    public partial class FrmColmenares : Form
    {
        public FrmColmenares()
        {
            InitializeComponent();
        }

        private ServicioColmenar _servicio;
        private List<Colmenar> _lista;


        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Colmenar producto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, producto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Colmenar colmenar)
        {
            r.Cells[CmnColmenar.Index].Value = colmenar.NombreColmenar;
            r.Cells[CmnCantidadColmena.Index].Value = colmenar.CantidadColmena;
            r.Cells[CmnCiudad.Index].Value = colmenar.Ciudad.ciudad;
            r.Cells[CmnEstadoColmenar.Index].Value = colmenar.EstadoColmena.estadoColmena;
            r.Cells[CmnInsumo.Index].Value = colmenar.Insumo.insumo;
            r.Cells[CmnCantidadInsumo.Index].Value = colmenar.CantidadInsumo;
            r.Tag = colmenar;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmColmenaresAE frm = new FrmColmenaresAE(this) { Text = "Agregar Colmenar" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Colmenar colmenar = (Colmenar)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la Colmenar {colmenar.NombreColmenar}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(colmenar.ColmenarID);
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
            Colmenar p = (Colmenar)r.Tag;
            p = _servicio.GetColmenarPorId(p.ColmenarID);
            FrmColmenaresAE frm = new FrmColmenaresAE();
            frm.Text = "Editar Colmenar";
            frm.SetColmenar(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetColmenar();
                    if (!_servicio.Existe(p))
                    {
                        _servicio.Guardar(p);
                        SetearFila(r, p);
                        MessageBox.Show("Registro modificado");
                    }
                    else
                    {
                        MessageBox.Show("Colmenar Repetido ");
                    }
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



        private void FrmColmenares_Load_1(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioColmenar();
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
