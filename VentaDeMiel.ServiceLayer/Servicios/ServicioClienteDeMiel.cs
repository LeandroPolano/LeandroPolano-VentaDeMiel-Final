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
    public class ServicioClienteDeMiel
    {
        private RepositorioClienteDeMiel _repositorioClienteDeMiel;
        private RepositorioTipoDocumento repositorioTipoDocumento;
        private RepositorioCiudad repositorioCiudad;

        private ConexionBD _conexion;
        public ClienteDeMiel GetClienteDeMielPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
             repositorioTipoDocumento= new RepositorioTipoDocumento(_conexion.AbrirConexion());
            _repositorioClienteDeMiel = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad, repositorioTipoDocumento);
            var p = _repositorioClienteDeMiel.GetClienteDeMielPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<ClienteDeMiel> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
            _repositorioClienteDeMiel = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad);

            var lista = _repositorioClienteDeMiel.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(ClienteDeMiel proveedor)
        {
            _conexion = new ConexionBD();
            _repositorioClienteDeMiel = new RepositorioClienteDeMiel(_conexion.AbrirConexion());
            _repositorioClienteDeMiel.Guardar(proveedor);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioClienteDeMiel = new RepositorioClienteDeMiel(_conexion.AbrirConexion());
            _repositorioClienteDeMiel.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(ClienteDeMiel proveedor)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
                repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                _repositorioClienteDeMiel = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad);

                var existe = _repositorioClienteDeMiel.Existe(proveedor);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ClienteDeMiel proveedor)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
                repositorioTipoDocumento = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                _repositorioClienteDeMiel = new RepositorioClienteDeMiel(_conexion.AbrirConexion(), repositorioCiudad);

                var relacionado = _repositorioClienteDeMiel.EstaRelacionado(proveedor);
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
