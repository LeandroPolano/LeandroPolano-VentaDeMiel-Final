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
   public class ServicioCiudad
    {
        private RepositorioCiudad _repositorioCiudad;
        private RepositorioProvincia _repositorioProvincia;
        private RepositorioPais repositorioPais;

        private ConexionBD _conexion;
        public Ciudad GetCiudadPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            _repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(),repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), _repositorioProvincia);
            var p = _repositorioCiudad.GetCiudadPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Ciudad> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            _repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), _repositorioProvincia);
            var lista = _repositorioCiudad.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Ciudad ciudad)
        {
            _conexion = new ConexionBD();
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioCiudad.Guardar(ciudad);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioCiudad.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
                _repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
                _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), _repositorioProvincia);
                var existe = _repositorioCiudad.Existe(ciudad);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());

                var relacionado = _repositorioCiudad.EstaRelacionado(ciudad);
                _conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public List<Ciudad> GetLista(int provinciaId)
        {
            _conexion = new ConexionBD(); 
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            _repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), _repositorioProvincia);
            var lista = _repositorioCiudad.GetLista(provinciaId);
            _conexion.CerrarConexion();
            return lista;

        }

        public List<Ciudad> GetLista(string ciudad)
        {
            _conexion = new ConexionBD(); 
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            _repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), _repositorioProvincia);
            var lista = _repositorioCiudad.GetLista(ciudad);
            _conexion.CerrarConexion();
            return lista;
        }
    }
}
