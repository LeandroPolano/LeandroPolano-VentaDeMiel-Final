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
    public partial class FrmEstadosColmenas : Form
    {
        public FrmEstadosColmenas()
        {
            InitializeComponent();
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmEstadosColmenasAE frm = new FrmEstadosColmenasAE(this);
            frm.Text = "Nuevo EstadoColmena";
            DialogResult dr = frm.ShowDialog(this);
  
        }
        private ServicioEstadoColmena _servicio;
        private List<EstadoColmena> _lista;
     

        internal void AgregarFila(EstadoColmena estadoColmena)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, estadoColmena);
            AgregarFila(r);
        }

        

        private void SetearFila(DataGridViewRow r, EstadoColmena estadoColmena)
        {
            r.Cells[CmlEstadoColmena.Index].Value = estadoColmena.estadoColmena;

            r.Tag = estadoColmena;

        }

      

        private void FrmEstadosColmenas_Load(object sender, EventArgs e)
        {
            try
            {
                Iniciar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Iniciar()
        {
            _servicio = new ServicioEstadoColmena();
            _lista = _servicio.GetLista();
            MostrarEnGrilla();
        }

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var estadoColmena in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, estadoColmena);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void BorrarToolStripButton_Click_1(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                EstadoColmena estadoColmena = (EstadoColmena)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el Estado de la Colmena {estadoColmena.estadoColmena}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(estadoColmena))
                    {

                        try
                        {
                            _servicio.Borrar(estadoColmena.EstadoColmenaID);
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

        private void EditarToolStripButton_Click_1(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                EstadoColmena estadoColmena = (EstadoColmena)r.Tag;
                estadoColmena = _servicio.GetEstadoColmenaPorId(estadoColmena.EstadoColmenaID);
                FrmEstadosColmenasAE frm = new FrmEstadosColmenasAE();
                frm.Text = "Editar EstadoColmena";
                frm.SetEstadoColmena(estadoColmena);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        estadoColmena = frm.GetEstadoColmena();
                        if (!_servicio.Existe(estadoColmena))
                        {
                            _servicio.Guardar(estadoColmena);
                            SetearFila(r, estadoColmena);

                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Tipo De Producto Repetido");
                            Iniciar();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void CerrarToolStripButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
