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
    public partial class FrmPaises : Form
    {
        public FrmPaises()
        {
            InitializeComponent();
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmPaisesAE frm = new FrmPaisesAE(this);
            frm.Text = "Nuevo Pais";
            DialogResult dr = frm.ShowDialog(this);
        }
        private ServicioPais _servicio;
        private List<Pais> _lista;
        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Pais pais = (Pais)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el pais {pais.pais}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(pais))
                    {

                        try
                        {
                            _servicio.Borrar(pais.PaisID);
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

        internal void AgregarFila(Pais pais)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, pais);
            AgregarFila(r);
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Pais pais = (Pais)r.Tag;
                pais = _servicio.GetPaisPorId(pais.PaisID);
                FrmPaisesAE frm = new FrmPaisesAE();
                frm.Text = "Editar Estado de colmena";
                frm.SetPais(pais);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        pais = frm.GetPais();
                        if (!_servicio.Existe(pais))
                        {
                            _servicio.Guardar(pais);
                            SetearFila(r, pais);
                            
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Estado De Colmena Repetido");
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

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[CmlPais.Index].Value = pais.pais;

            r.Tag = pais;
            
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPaises_Load(object sender, EventArgs e)
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
            _servicio = new ServicioPais();
            _lista = _servicio.GetLista();
            MostrarEnGrilla();
        }

        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var pais in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pais);
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
    }
}
