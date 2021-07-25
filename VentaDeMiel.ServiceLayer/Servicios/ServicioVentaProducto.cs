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
    public class ServicioVentaProducto
    {
        private RepositorioProducto _repositorioProducto;
        private RepositorioVenta repositorioVenta;
        private RepositorioTipoEnvase repositorioTipoEnvase;
        private RepositorioVentaProducto _repositorioVentaProducto;

        private ConexionBD _conexion;
        public Producto GetProductoPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());
            repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
            _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());
            var p = _repositorioProducto.GetProductoPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Producto> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());
            repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
            _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());

            var lista = _repositorioProducto.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        //public void Guardar(Producto producto)
        //{
        //    _conexion = new ConexionBD();
        //    _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());
        //    _repositorioProducto.Guardar(producto);
        //    _conexion.CerrarConexion();
        //}

        public void Borrar(VentaProducto ventaProducto)
        {
            _conexion = new ConexionBD();
            _repositorioVentaProducto = new RepositorioVentaProducto(_conexion.AbrirConexion());
            _repositorioVentaProducto.Borrar(ventaProducto);
            _conexion.CerrarConexion();
        }

        //public bool Existe(Producto producto)
        //{
        //    try
        //    {
        //        _conexion = new ConexionBD();
        //        repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());
        //        repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
        //        _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());

        //        var existe = _repositorioProducto.Existe(producto);
        //        _conexion.CerrarConexion();
        //        return existe;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public bool EstaRelacionado(VentaProducto ventaProducto)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioVenta = new RepositorioVenta(_conexion.AbrirConexion());
                repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
                _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());

                var relacionado = _repositorioVentaProducto.EstaRelacionado(ventaProducto);
                _conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
