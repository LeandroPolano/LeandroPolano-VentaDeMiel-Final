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
    public class ServicioProveedor
    {
        private RepositorioProveedor _repositorioProveedor;
        private RepositorioCiudad repositorioCiudad;

        private ConexionBD _conexion;
        public Proveedor GetProveedorPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);
            var p = _repositorioProveedor.GetProveedorPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Proveedor> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);

            var lista = _repositorioProveedor.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Proveedor proveedor)
        {
            _conexion = new ConexionBD();
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
            _repositorioProveedor.Guardar(proveedor);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion());
            _repositorioProveedor.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
                _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);

                var existe = _repositorioProveedor.Existe(proveedor);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
                _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);

                var relacionado = _repositorioProveedor.EstaRelacionado(proveedor);
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
