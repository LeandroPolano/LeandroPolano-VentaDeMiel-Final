using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;
using VentaDeMiel.DataLayer;
using VentaDeMiel.DataLayer.Repositorios;

namespace VentaDeMiel.ServiceLayer.Servicios
{
    public class ServicioVenta
    {
        private RepositorioVenta _repositorioVenta;
        private RepositorioClienteDeMiel _repositorioCliente;
        private RepositorioCiudad repositorioCiudad;
        private RepositorioTipoDocumento repositorioTipoDocumento;
        private RepositorioVentaProducto repositorioVentaProducto;

        private ConexionBD _conexion;
        public Venta GetVentaPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
            _repositorioCliente = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad, repositorioTipoDocumento);
            _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion(), _repositorioCliente);
            var p = _repositorioVenta.GetVentaPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Venta> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
            _repositorioCliente = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad, repositorioTipoDocumento);
            _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion(), _repositorioCliente);
            var lista = _repositorioVenta.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Venta venta)
        {
            _conexion = new ConexionBD();
            _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());
            repositorioVentaProducto = new RepositorioVentaProducto(_conexion.AbrirConexion()) ;
            _repositorioVenta.Guardar(venta);
            foreach (var vp in venta.VentaProductos)
            {
                vp.Venta = venta;
                repositorioVentaProducto.Guardar(vp);
            }
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());
            _repositorioVenta.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Venta insumo)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
                repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                _repositorioCliente = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad, repositorioTipoDocumento);
                _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion(), _repositorioCliente);
                var existe = _repositorioVenta.Existe(insumo);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Venta insumo)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());

                var relacionado = _repositorioVenta.EstaRelacionado(insumo);
                _conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public List<Venta> GetLista(int proveedorId)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
            _repositorioCliente = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad, repositorioTipoDocumento);
            _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion(), _repositorioCliente);
            var lista = _repositorioVenta.GetLista(proveedorId);
            _conexion.CerrarConexion();
            return lista;

        }

        public List<Venta> GetLista(string insumo)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
            _repositorioCliente = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad, repositorioTipoDocumento);
            _repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion(), _repositorioCliente);
            var lista = _repositorioVenta.GetLista(insumo);
            _conexion.CerrarConexion();
            return lista;
        }
    }
}
