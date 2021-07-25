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
   public class ServicioPais
    {
        private ConexionBD _conexion;
        private RepositorioPais _repositorio;

        public ServicioPais()
        {

        }
        public Pais GetPaisPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioPais(_conexion.AbrirConexion());
                var pais = _repositorio.GetPaisPorId(id);
                _conexion.CerrarConexion();
                return pais;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Pais> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioPais(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Pais pais)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioPais(_conexion.AbrirConexion());
                _repositorio.Guardar(pais);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioPais(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioPais(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(pais);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioPais(_conexion.AbrirConexion());
                var relacionado = _repositorio.EstaRelacionado(pais);
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
