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
    public partial class FrmProvincias : Form
    {
        public FrmProvincias()
        {
            InitializeComponent();
        }
        private ServicioProvincia _servicio;
        private List<Provincia> _lista;
        private void FrmProvincia_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioProvincia();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception exception)
            {
               MessageBox.Show(exception.Message);
            }
        }

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(Provincia producto)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, producto);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Provincia provincia)
        {
            r.Cells[CmlProvincia.Index].Value = provincia.provincia;
            r.Cells[ClmPaisID.Index].Value = provincia.Pais.pais;
            r.Tag = provincia;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmProvinciasAE frm = new FrmProvinciasAE(this) { Text = "Agregar Producto" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Provincia provincia = (Provincia)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la Provincia {provincia.provincia}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    if (!_servicio.EstaRelacionado(provincia))
                    {
                       
                        try
                        {
                            _servicio.Borrar(provincia.ProvinciaID);
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
            Provincia p = (Provincia)r.Tag;
            p = _servicio.GetProvinciaPorId(p.ProvinciaID);
            FrmProvinciasAE frm = new FrmProvinciasAE();
            frm.Text = "Editar Provincia";
            frm.SetProvincia(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetProvincia();
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
    }
}
