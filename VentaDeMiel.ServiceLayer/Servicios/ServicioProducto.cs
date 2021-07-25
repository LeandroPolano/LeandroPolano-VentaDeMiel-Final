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
    public class ServicioProducto
    {

        private RepositorioProducto _repositorioProducto;
        private RepositorioTipoProducto repositorioTipoProducto;
        private RepositorioMarca repositorioMarca;

        private ConexionBD _conexion;
        public Producto GetProductoPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioTipoProducto = new RepositorioTipoProducto(_conexion.AbrirConexion());
            repositorioMarca = new RepositorioMarca(_conexion.AbrirConexion());
            _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion(), repositorioMarca, repositorioTipoProducto);
            var p = _repositorioProducto.GetProductoPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Producto> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioTipoProducto = new RepositorioTipoProducto(_conexion.AbrirConexion());
            repositorioMarca = new RepositorioMarca(_conexion.AbrirConexion());
            _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion(), repositorioMarca, repositorioTipoProducto);

            var lista = _repositorioProducto.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Producto producto)
        {
            _conexion = new ConexionBD();
            _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());
            _repositorioProducto.Guardar(producto);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion());
            _repositorioProducto.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Producto producto)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioTipoProducto = new RepositorioTipoProducto(_conexion.AbrirConexion());
                repositorioMarca = new RepositorioMarca(_conexion.AbrirConexion());
                _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion(), repositorioMarca, repositorioTipoProducto);

                var existe = _repositorioProducto.Existe(producto);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioTipoProducto = new RepositorioTipoProducto(_conexion.AbrirConexion());
                repositorioMarca = new RepositorioMarca(_conexion.AbrirConexion());
                _repositorioProducto = new RepositorioProducto(_conexion.AbrirConexion(), repositorioMarca, repositorioTipoProducto);

                var relacionado = _repositorioProducto.EstaRelacionado(producto);
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
