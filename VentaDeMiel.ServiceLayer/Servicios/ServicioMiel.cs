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
    public class ServicioMiel
    {
        private ConexionBD _conexion;
        private RepositorioMiel _repositorio;

        public ServicioMiel()
        {

        }
        public Miel GetMielPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMiel(_conexion.AbrirConexion());
                var miel = _repositorio.GetMielPorId(id);
                _conexion.CerrarConexion();
                return miel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Miel> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMiel(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Miel miel)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMiel(_conexion.AbrirConexion());
                _repositorio.Guardar(miel);
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
                _repositorio = new RepositorioMiel(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Miel miel)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMiel(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(miel);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Miel miel)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMiel(_conexion.AbrirConexion());
                var existe = _repositorio.EstaRelacionado(miel);
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
