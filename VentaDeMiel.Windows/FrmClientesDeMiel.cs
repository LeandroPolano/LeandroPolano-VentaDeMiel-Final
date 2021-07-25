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
    public partial class FrmClientesDeMiel : Form
    {
        public FrmClientesDeMiel()
        {
            InitializeComponent();
        }
        private ServicioClienteDeMiel _servicio;
        private List<ClienteDeMiel> _lista;


        private void MostrarEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in _lista)
            {
                AgregarFila(producto);
            }
        }

        public void AgregarFila(ClienteDeMiel clienteDeMiel)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, clienteDeMiel);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ClienteDeMiel clienteDeMiel)
        {
            r.Cells[CmlRazonSocial.Index].Value = clienteDeMiel.RazonSocial;
            r.Cells[CmlDireccion.Index].Value = clienteDeMiel.Direccion;
            r.Cells[CmlCiudad.Index].Value = clienteDeMiel.Ciudad.ciudad;
            r.Cells[CmlCodigoPostal.Index].Value = clienteDeMiel.CodigoPostal;
            r.Cells[CmlTelefono.Index].Value = clienteDeMiel.Telefono;
            r.Cells[CmlEmail.Index].Value = clienteDeMiel.Email;
            r.Cells[CmlTipoDocumento.Index].Value = clienteDeMiel.TipoDocumento.tipoDocumento;
            r.Cells[CmlNumeroDocumento.Index].Value = clienteDeMiel.NumeroDocumento;
            r.Tag = clienteDeMiel;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmClientesDeMielAE frm = new FrmClientesDeMielAE(this) { Text = "Agregar Cliente De Miel" };
            DialogResult dr = frm.ShowDialog(this);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                ClienteDeMiel producto = (ClienteDeMiel)r.Tag;


                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a el cliente {producto.RazonSocial}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(producto.ClienteID);
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
            ClienteDeMiel p = (ClienteDeMiel)r.Tag;
            p = _servicio.GetClienteDeMielPorId(p.ClienteID);
            FrmClientesDeMielAE frm = new FrmClientesDeMielAE();
            frm.Text = "Editar Cliente De Miel";
            frm.SetClienteDeMiel(p);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    p = frm.GetClienteDeMiel();
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

        private void FrmClientesDeMiel_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioClienteDeMiel();
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
