using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;
using VentaDeMiel.DataLayer;
using VentaDeMiel.DataLayer.Repositorios;

namespace VentaDeMiel.ServiceLayer.Servicios
{
    public class ServicioColmenar
    {
        private RepositorioColmenar _repositorioColmenar;
        private RepositorioCiudad _repositorioCiudad;
        private RepositorioProvincia repositorioProvincia;
        private RepositorioPais repositorioPais;
        private RepositorioEstadoColmena repositorioEstadoColmena;
        private RepositorioInsumo repositorioInsumo;
        private RepositorioProveedor repositorioProveedor;
        private SqlTransaction transaction;

        private ConexionBD _conexion;
        public Colmenar GetColmenarPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(),repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(),repositorioProvincia);
            repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), repositorioProveedor);
            _repositorioColmenar = new RepositorioColmenar(_conexion.AbrirConexion(), _repositorioCiudad, repositorioEstadoColmena, repositorioInsumo);
            var p = _repositorioColmenar.GetColmenarPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Colmenar> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), repositorioProvincia);
            repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), repositorioProveedor);
            _repositorioColmenar = new RepositorioColmenar(_conexion.AbrirConexion(), _repositorioCiudad, repositorioEstadoColmena, repositorioInsumo);
            var lista = _repositorioColmenar.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Colmenar colmenar)
        {
            try
            {
                _conexion = new ConexionBD();
                SqlConnection cn = _conexion.AbrirConexion();
                transaction = cn.BeginTransaction();
                _repositorioColmenar = new RepositorioColmenar(cn, transaction);
                repositorioInsumo = new RepositorioInsumo(cn, transaction);
                repositorioInsumo.EditarInsumo(colmenar);
                _repositorioColmenar.Guardar(colmenar);
                transaction.Commit();
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioColmenar = new RepositorioColmenar(_conexion.AbrirConexion());
            _repositorioColmenar.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Colmenar colmenar)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
                repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
                _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), repositorioProvincia);
                repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), repositorioProveedor);
                _repositorioColmenar = new RepositorioColmenar(_conexion.AbrirConexion(), _repositorioCiudad, repositorioEstadoColmena, repositorioInsumo);
                var existe = _repositorioColmenar.Existe(colmenar);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Colmenar colmenar)
        {
            throw new System.NotImplementedException();
        }



        public List<Colmenar> GetLista(int ciudadId)
        {
            _conexion = new ConexionBD();
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), repositorioProvincia);
            repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), repositorioProveedor);
            _repositorioColmenar = new RepositorioColmenar(_conexion.AbrirConexion(), _repositorioCiudad, repositorioEstadoColmena, repositorioInsumo);
            var lista = _repositorioColmenar.GetLista(ciudadId);
            _conexion.CerrarConexion();
            return lista;

        }

        public List<Colmenar> GetLista(string colmenar)
        {
            _conexion = new ConexionBD();
            repositorioPais = new RepositorioPais(_conexion.AbrirConexion());
            repositorioProvincia = new RepositorioProvincia(_conexion.AbrirConexion(), repositorioPais);
            _repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion(), repositorioProvincia);
            repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), repositorioProveedor);
            _repositorioColmenar = new RepositorioColmenar(_conexion.AbrirConexion(), _repositorioCiudad, repositorioEstadoColmena, repositorioInsumo);
            var lista = _repositorioColmenar.GetLista(colmenar);
            _conexion.CerrarConexion();
            return lista;
        }
    }
}
