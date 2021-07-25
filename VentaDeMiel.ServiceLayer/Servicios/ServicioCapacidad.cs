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
    public class ServicioCapacidad
    {
        private ConexionBD _conexion;
        private RepositorioCapacidad _repositorio;

        public ServicioCapacidad()
        {

        }
        public Capacidad GetCapacidadPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCapacidad(_conexion.AbrirConexion());
                var capacidad = _repositorio.GetCapacidadPorId(id);
                _conexion.CerrarConexion();
                return capacidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Capacidad> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCapacidad(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Capacidad capacidad)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCapacidad(_conexion.AbrirConexion());
                _repositorio.Guardar(capacidad);
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
                _repositorio = new RepositorioCapacidad(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Capacidad capacidad)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCapacidad(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(capacidad);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Capacidad capacidad)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCapacidad(_conexion.AbrirConexion());
                var existe = _repositorio.EstaRelacionado(capacidad);
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
