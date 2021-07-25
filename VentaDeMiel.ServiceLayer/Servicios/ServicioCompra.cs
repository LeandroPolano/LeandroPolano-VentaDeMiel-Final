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
   public class ServicioCompra
    {
        private RepositorioCompra _repositorioCompra;
        private RepositorioProveedor _repositorioProveedor;
        private RepositorioCompraInsumo repositorioCompraInsumo;
        private RepositorioInsumo repositorioInsumo;

        private ConexionBD _conexion;
        public Compra GetCompraPorId(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
            _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion(), _repositorioProveedor);
            var p = _repositorioCompra.GetCompraPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Compra> GetLista()
        {
            _conexion = new ConexionBD();
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
            _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion(), _repositorioProveedor);
            var lista = _repositorioCompra.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Compra compra)
        {
            _conexion = new ConexionBD();
            _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());
            repositorioCompraInsumo = new RepositorioCompraInsumo(_conexion.AbrirConexion());
            _repositorioCompra.Guardar(compra);
            foreach (var vp in compra.CompraInsumos)
            {
                vp.Compra = compra;
                repositorioCompraInsumo.Guardar(vp);
            }
            repositorioInsumo=new RepositorioInsumo(_conexion.AbrirConexion());
            repositorioInsumo.ActualizarStock(compra);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());
            _repositorioCompra.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Compra insumo)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
                _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion(), _repositorioProveedor);
                var existe = _repositorioCompra.Existe(insumo);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Compra insumo)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());

                var relacionado = _repositorioCompra.EstaRelacionado(insumo);
                _conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public List<Compra> GetLista(int proveedorId)
        {
            _conexion = new ConexionBD();
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
            _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion(), _repositorioProveedor);
            var lista = _repositorioCompra.GetLista(proveedorId);
            _conexion.CerrarConexion();
            return lista;

        }

        //public List<Compra> GetLista(string insumo)
        //{
        //    _conexion = new ConexionBD();
        //    _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
        //    _repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion(), _repositorioProveedor);
        //    var lista = _repositorioCompra.GetLista(insumo);
        //    _conexion.CerrarConexion();
        //    return lista;
        //}
    }
}
