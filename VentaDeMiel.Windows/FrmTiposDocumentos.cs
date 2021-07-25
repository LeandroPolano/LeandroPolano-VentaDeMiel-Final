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
    public partial class FrmMiel : Form
    {
        public FrmMiel()
        {
            InitializeComponent();
        }
        private ServicioTipoDocumento _servicio;
        private List<TipoDocumento> _lista;
        private void FrmTiposDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioTipoDocumento();
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
            foreach (var TipoDocumento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, TipoDocumento);
                AgregarFila(r);
            }
        }

        internal void AgregarFila(TipoDocumento tipodocumento)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, tipodocumento);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDocumento tipodocumento)
        {
            r.Cells[CmlTipoDocumento.Index].Value = tipodocumento.tipoDocumento;

            r.Tag = tipodocumento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmTiposDocumentosAE frm = new FrmTiposDocumentosAE (this);
            frm.Text = "Nuevo Tipo de Documento";
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                TipoDocumento tipodocumento = (TipoDocumento)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el tipo de documento {tipodocumento.tipoDocumento}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(tipodocumento.TipoDocumentoID);
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
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                TipoDocumento tipodocumento = (TipoDocumento)r.Tag;
                tipodocumento = _servicio.GetTipoDocumentoPorId(tipodocumento.TipoDocumentoID);
                FrmTiposDocumentosAE frm = new FrmTiposDocumentosAE();
                frm.Text = "Editar Tipo de documento";
                frm.SetTipoDocumento(tipodocumento);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipodocumento = frm.GetTipoDocumento();
                        if (!_servicio.Existe(tipodocumento))
                        {
                            _servicio.Guardar(tipodocumento);
                            SetearFila(r, tipodocumento);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Problema Repetido");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
