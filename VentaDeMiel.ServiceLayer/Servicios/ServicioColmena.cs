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
    public class ServicioColmena
    {
        private ConexionBD _conexion;
        private RepositorioColmena _repositorio;

        public ServicioColmena()
        {

        }
        public Colmena GetColmenaPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioColmena(_conexion.AbrirConexion());
                var ClaveColmena = _repositorio.GetColmenaPorId(id);
                _conexion.CerrarConexion();
                return ClaveColmena;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Colmena> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioColmena(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Colmena ClaveColmena)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioColmena(_conexion.AbrirConexion());
                _repositorio.Guardar(ClaveColmena);
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
                _repositorio = new RepositorioColmena(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Colmena ClaveColmena)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioColmena(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(ClaveColmena);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Colmena ClaveColmena)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioColmena(_conexion.AbrirConexion());
                var existe = _repositorio.EstaRelacionado(ClaveColmena);
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
