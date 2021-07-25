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
    public partial class FrmCiudades : Form
    {
        public FrmCiudades()
        {
            InitializeComponent();
        }

        
        private ServicioCiudad _servicio;
        private List<Ciudad> _lista;
        

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Ciudad producto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, producto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Ciudad ciudad)
        {
            r.Cells[CmnCiudad.Index].Value = ciudad.ciudad;
            r.Cells[CmnProvincia.Index].Value = ciudad.Provincia.provincia;
            r.Tag = ciudad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmCiudadesAE frm = new FrmCiudadesAE(this) { Text = "Agregar Producto" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Ciudad ciudad = (Ciudad)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la Ciudad {ciudad.ciudad}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                     if (!_servicio.EstaRelacionado(ciudad))
                    {
                       
                    try
                    {
                        _servicio.Borrar(ciudad.CiudadID);
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
            Ciudad p = (Ciudad)r.Tag;
            p = _servicio.GetCiudadPorId(p.CiudadID);
            FrmCiudadesAE frm = new FrmCiudadesAE();
            frm.Text = "Editar Ciudad";
            frm.SetCiudad(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetCiudad();
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

        private void FrmCiudades_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioCiudad();
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
