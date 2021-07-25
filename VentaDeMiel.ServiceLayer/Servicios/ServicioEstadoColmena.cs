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
    public class ServicioEstadoColmena
    {
        private ConexionBD _conexion;
        private RepositorioEstadoColmena _repositorio;

        EstadoColmena Estado=new EstadoColmena();
        public ServicioEstadoColmena()
        {

        }
        public EstadoColmena GetEstadoColmenaPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioEstadoColmena(_conexion.AbrirConexion());
                var estadoColmena = _repositorio.GetEstadoColmenaPorId(id);
                _conexion.CerrarConexion();
                return estadoColmena;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<EstadoColmena> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioEstadoColmena(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(EstadoColmena estadoColmena)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioEstadoColmena(_conexion.AbrirConexion());
                _repositorio.Guardar(estadoColmena);
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
                _repositorio = new RepositorioEstadoColmena(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(EstadoColmena estadoColmena)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioEstadoColmena(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(estadoColmena);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(EstadoColmena estadoColmena)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioEstadoColmena(_conexion.AbrirConexion());
                var existe = _repositorio.EstaRelacionado(estadoColmena);
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
