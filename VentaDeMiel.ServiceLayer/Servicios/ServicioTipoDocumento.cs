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
   public class ServicioTipoDocumento
    {
        private ConexionBD _conexion;
        private RepositorioTipoDocumento _repositorio;

        public ServicioTipoDocumento()
        {

        }
        public TipoDocumento GetTipoDocumentoPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                var tipodocumento = _repositorio.GetTipoDocumentoPorId(id);
                _conexion.CerrarConexion();
                return tipodocumento;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<TipoDocumento> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDocumento tipodocumento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                _repositorio.Guardar(tipodocumento);
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
                _repositorio = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDocumento tipodocumento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(tipodocumento);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDocumento tipodocumento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDocumento(_conexion.AbrirConexion());
                var existe = _repositorio.EstaRelacionado(tipodocumento);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
